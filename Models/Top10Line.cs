//
// One CTA Line
//

namespace program.Models
{

  public class Top10Line
	{
	
		// data members with auto-generated getters and setters:
	     public int StationID { get; set; }
		public string StationName { get; set; }
	     public int NumRiders { get; set; }
       
		// default constructor:
		public Top10Line()
		{ }
		
		// constructor:
		public Top10Line(int id, string name, int numriders)
		{
			StationID = id;
			StationName = name;
               NumRiders = numriders;
		}
		
	}//class

}//namespace