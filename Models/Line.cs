//
// One CTA Line
//

namespace program.Models
{

  public class Line
	{
	
		// data members with auto-generated getters and setters:
	     public int StationID { get; set; }
		public string StationName { get; set; }
	     public int TotalStops { get; set; }
       
		// default constructor:
		public Line()
		{ }
		
		// constructor:
		public Line(int id, string name, int total)
		{
			StationID = id;
			StationName = name;
               TotalStops = total;
		}
		
	}//class

}//namespace