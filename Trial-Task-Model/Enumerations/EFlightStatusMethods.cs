using System;
using System.Collections.Generic;
using System.Text;

namespace Trial_Task_Model.Enumerations
{
	public static class EFlightStatusMethods
	{
		public static string GetName(this EFlightStatus role)
		{
			return Enum.GetName(typeof(EFlightStatus), role);
		}
		public static EFlightStatus SetTo(this ref EFlightStatus target, string roleName)
		{
			switch (roleName.ToLower().Trim())
			{
				case "approved":
				case "1":
					return target = EFlightStatus.Approved;
				case "rejected":
				case "2":
					return target = EFlightStatus.Rejected;
				case "pending":
				case "underapproval":
				case "under approval":
				case "0":
					return target = EFlightStatus.Pending;
			}
			throw new ArgumentException("invalid Role Name");
		}

	}
}
