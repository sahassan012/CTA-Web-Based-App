using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class LineInfoModel : PageModel  
    {  
				public List<Models.Line> LineList { get; set; }
				public string Input { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  LineList = new List<Models.Line>();
					
					// make input available to web page:
					Input = input;
					
					// clear exception:
					EX = null;
					
					try
					{
						//
						// Do we have an input argument?  If not, there's nothing to do:
						//
						if (input == null)
						{
							//
							// there's no page argument, perhaps user surfed to the page directly?  
							// In this case, nothing to do.
							//
						}
						else  
						{
							// 
							// Lookup movie(s) based on input, which could be id or a partial name:
							// 
							string sql;

						  // lookup station(s) by partial name match:
							input = input.Replace("'", "''");

							sql = string.Format(@"
	SELECT tableA.StationID, tableB.Name, tableB.TotalStops
     FROM 
         (SELECT StationOrder.LineID, StationOrder.StationID, StationOrder.Position
         FROM StationOrder
         LEFT JOIN lines on lines.LineID = StationOrder.LineID
         WHERE lines.Color LIKE '%{0}%') as tableA,

         (SELECT Stations.StationID, Stations.Name, count(Stops.StationID) as TotalStops
         FROM Stations
         LEFT JOIN Stops ON Stations.StationID = Stops.StationID
         GROUP BY Stations.StationID, Stations.Name) as tableB

     WHERE tableA.StationID = tableB.StationID
     ORDER BY tableA.Position ASC
	", input);

							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables[0].Rows)
							{
								Models.Line s = new Models.Line();

								s.StationID = Convert.ToInt32(row["StationID"]);
								s.StationName = Convert.ToString(row["Name"]);
                                        s.TotalStops = Convert.ToInt32(row["TotalStops"]);
     
								LineList.Add(s);
							}
						}//else
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
					  // nothing at the moment
				  }
				}
			
    }//class  
}//namespace