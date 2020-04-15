using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class Top10LineInfoModel : PageModel  
    {  
				public List<Models.Top10Line> Top10LineList { get; set; }
				public string Input { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  Top10LineList = new List<Models.Top10Line>();
					
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
	SELECT TOP 10 Stations.StationID, Stations.Name, Sum(DailyTotal) AS NumRiders
     FROM Riderships
     INNER JOIN Stations on Stations.StationID = Riderships.StationID
     WHERE Stations.Name LIKE '%{0}%'
     GROUP BY Stations.StationID, Stations.Name
     ORDER BY NumRiders DESC
	", input);

							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables[0].Rows)
							{
								Models.Top10Line s = new Models.Top10Line();

								s.StationID = Convert.ToInt32(row["StationID"]);
								s.StationName = Convert.ToString(row["Name"]);
                                        s.NumRiders = Convert.ToInt32(row["NumRiders"]);
     
								Top10LineList.Add(s);
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