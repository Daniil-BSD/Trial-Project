namespace Trial_Task_Model.Interfaces
{
	/*
	 * Interface meant for ease of measuring distances between points wiithout full Inheritance or definition of a separate class to be stored in a separate table.
	 */
	/// <summary>
	/// Defines the <see cref="IGlobalPoint" />
	/// </summary>
	public interface IGlobalPoint
	{
		double Latitude { get; set; }

		double Longitude { get; set; }
	}
}
