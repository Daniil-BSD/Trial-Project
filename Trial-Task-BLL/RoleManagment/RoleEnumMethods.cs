using System;
using System.Linq;
using static Trial_Task_BLL.RoleManagment.Role;

namespace Trial_Task_BLL.RoleManagment
{
	/// <summary>
	/// <see cref="RoleEnum"/> methods.
	/// </summary>
	static class RoleEnumMethods
	{
		/// <summary>
		/// Less ambigious "toString()", but functially identical
		/// </summary>
		/// <param name="role">The role<see cref="RoleEnum"/></param>
		/// <returns>The <see cref="string"/></returns>
		public static string GetName(this RoleEnum role)
		{
			return Enum.GetName(typeof(RoleEnum), role);
		}

		/// <summary>
		/// Converts an array of roles into a single string (like those used by attributes)
		/// </summary>
		/// <param name="roles">The roles<see cref="RoleEnum[]"/></param>
		/// <returns>The <see cref="string"/></returns>
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
