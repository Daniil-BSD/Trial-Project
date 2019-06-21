using System;
using System.Linq;
using static Trial_Task_BLL.RoleManagment.Role;

namespace Trial_Task_BLL.RoleManagment
{
	/// <summary>
	/// Defines the <see cref="RoleEnumMethods" />
	/// </summary>
	static class RoleEnumMethods
	{
		public static string GetName(this RoleEnum role)
		{
			return Enum.GetName(typeof(RoleEnum), role);
		}

		public static string ToSingleString(this RoleEnum[] roles)
		{
			string ret = "";
			var distinctRoles = roles.Distinct();
			bool first = true;
			foreach (RoleEnum role in distinctRoles)
			{
				if (!first) ret += ", "; else first = false;
				ret += role.ToString();
			}
			return ret;
		}
	}
}
