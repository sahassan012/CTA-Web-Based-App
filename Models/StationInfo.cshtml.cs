using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class StationInfoModel : PageModel  
    {  
				public List<Models.Station> StationList { get; set; }
				public string Input { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  StationList = new List<Models.Station>();
					
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
	SELECT tableA.StationID, tableA.Name, tableA.AvgDailyRidership, tableB.TotalStops, tableC.Accessibility
     FROM 
         (SELECT Stations.StationID as StationID, Stations.Name as Name, AVG(DailyTotal) AS AvgDailyRidership
         FROM Stations
         LEFT JOIN Riderships ON Stations.StationID = Riderships.StationID
         WHERE Stations.Name LIKE '%{0}%'
         GROUP BY Stations.StationID, Stations.Name) as tableA,

         (SELECT Stations.StationID, count(Stops.StationID) as TotalStops
         FROM Stations
         LEFT JOIN Stops ON Stations.StationID = Stops.StationID
         GROUP BY Stations.StationID) as tableB,

         (SELECT Stations.StationID,
         CASE 
         WHEN SUM(CAST(Stops.ADA AS INT)) = 0 THEN 'none'
         WHEN SUM(CAST(Stops.ADA AS INT)) = COUNT(Stops.StationID) THEN 'all'
         WHEN SUM(CAST(Stops.ADA AS INT)) <> COUNT(Stops.StationID) THEN 'some'
         END as Accessibility 
         FROM Stations
         LEFT JOIN Stops ON Stations.StationID = Stops.StationID
         GROUP BY Stations.StationID) as tableC

     WHERE tableA.StationID = tableB.StationID AND tableB.StationID = tableC.StationID
     ORDER BY TableA.Name ASC;
	", input);

							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables[0].Rows)
							{
								Models.Station s = new Models.Station();

								s.StationID = Convert.ToInt32(row["StationID"]);
								s.StationName = Convert.ToString(row["Name"]);
                                        s.TotalStops = Convert.ToInt32(row["TotalStops"]);
                                        
								// avg could be null if there is no ridership data:
								if (row["AvgDailyRidership"] == System.DBNull.Value)
									s.AvgDailyRidership = 0;
								else
									s.AvgDailyRidership = Convert.ToInt32(row["AvgDailyRidership"]);
                                        
                                        // Acessibility could be null if there is no ridership data:
								if (row["Accessibility"] == System.DBNull.Value)
									s.Accessibility = "none";
								else
									s.Accessibility = Convert.ToString(row["Accessibility"]);
                                             
								StationList.Add(s);
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