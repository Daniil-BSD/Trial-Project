using System;

namespace Trial_Task_Model.Interfaces
{
	/// <summary>
	/// Interface that Indicates that the implementing class members will be Identified by <see cref="Guid"/> ID field.
	/// Used for creation of generalized get requests
	/// </summary>
	public interface IGuidIdentifyable
	{
		Guid ID { get; set; }
	}
}
