using System.ComponentModel;

namespace Trial_Task_Model.Enumerations
{
	/// <summary>
	/// Defines the 3 statee a <see cref="Flight"/> could be in.
	/// </summary>
	public enum EFlightStatus : byte
	{
		/// <summary>
		/// Default state.
		/// </summary>
		[Description("under approval")]
		Pending = 0,

		/// <summary>
		/// State after a sucessful approval (likly public visibility).
		/// </summary>
		[Description("approved")]
		Approved = 1,

		/// <summary>
		/// State after a regection (likly limited visibility).
		/// </summary>
		[Description("rejected")]
		Rejected = 2
	}
}
