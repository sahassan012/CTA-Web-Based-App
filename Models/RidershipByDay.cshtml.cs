using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
  
namespace program.Pages  
{  
    public class RidershipByDayModel : PageModel  
    {  
        public List<string> Days { get; set; }
        public List<int> NumRiders { get; set; }
        public Exception EX { get; set; }
  
        public void OnGet()  
        {
          Days = new List<string>();
          NumRiders = new List<int>();
          
          EX = null;
          
          Days.Add("Mon");
          Days.Add("Tue");
          Days.Add("Wed");
          Days.Add("Thu");
          Days.Add("Fri");
          Days.Add("Sat");
          Days.Add("Sun");
          
          try
          {
            string sql = string.Format(@"
         SELECT DATENAME(WEEKDAY, theDate) as Day, Sum(DailyTotal) AS NumRiders
         FROM Riderships
         GROUP BY DATENAME(WEEKDAY, theDate)
         ORDER BY 
          CASE
             WHEN DATENAME(WEEKDAY, theDate) = 'Monday' THEN 1
             WHEN DATENAME(WEEKDAY, theDate) = 'Tuesday' THEN 2
             WHEN DATENAME(WEEKDAY, theDate) = 'Wednesday' THEN 3
             WHEN DATENAME(WEEKDAY, theDate) = 'Thursday' THEN 4
             WHEN DATENAME(WEEKDAY, theDate) = 'Friday' THEN 5
             WHEN DATENAME(WEEKDAY, theDate) = 'Saturday' THEN 6
             WHEN DATENAME(WEEKDAY, theDate) = 'Sunday' THEN 7
          END ASC
");
          
            DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
              int numriders = Convert.ToInt32(row["NumRiders"]);

              NumRiders.Add(numriders);
            }
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