using System.ComponentModel;

namespace Trial_Task_Model.Enumerations
{
	public enum EFlightStatus : byte
	{
		[Description("under approval")]
		Pending = 0,
		[Description("approved")]
		Approved = 1,
		[Description("rejected")]
		Rejected = 2
	}
}
