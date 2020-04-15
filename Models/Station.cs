//
// One CTA Station
//

namespace program.Models
{

  public class Station
	{
	
		// data members with auto-generated getters and setters:
	     public int StationID { get; set; }
		public string StationName { get; set; }
		public int AvgDailyRidership { get; set; }
	     public int TotalStops { get; set; }
          public string Accessibility { get; set; }
       
		// default constructor:
		public Station()
		{ }
		
		// constructor:
		public Station(int id, string name, int avgDailyRidership, int total, string accessibility)
		{
			StationID = id;
			StationName = name;
			AvgDailyRidership = avgDailyRidership;
               TotalStops = total;
               Accessibility = accessibility;
		}
		
	}//class

}//namespace