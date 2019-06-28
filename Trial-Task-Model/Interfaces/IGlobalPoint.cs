namespace Trial_Task_Model.Interfaces
{
	/// <summary>
	/// Interface shared by Model classes that include global position information.
	/// Meant for measuring distances between different objects with appropriate attributes.
	/// Note: Used as an intereface instead of a struct or a class to keep all datastructures simple
	/// </summary>
	public interface IGlobalPoint
	{
		double Latitude { get; set; }

		double Longitude { get; set; }
	}
}
