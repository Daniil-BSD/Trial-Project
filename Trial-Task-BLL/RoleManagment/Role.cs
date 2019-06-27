using System;

namespace Trial_Task_BLL.RoleManagment
{
	/// <summary>
	/// <see cref="RoleEnum"/> wrapper.
	/// </summary>
	partial struct Role
	{
		private RoleEnum value;

		public RoleEnum Value
		{
			get { return value; }
			set { this.value = value; }
		}

		public Role(RoleEnum role)
		{
			value = role;
		}

		public Role(string roleName)
		{
			value = ParseString(roleName);
		}

		/// <summary>
		/// Converts <see cref="RoleEnum"/> array to <see cref="Role"/> array.
		/// </summary>
		/// <param name="roleEnums">The <see cref="RoleEnum[]"/> to be converted</param>
		/// <returns>The <see cref="Role[]"/></returns>
		public static Role[] RoleEnumsToRoles(RoleEnum[] roleEnums)
		{
			Role[] roles = new Role[roleEnums.Length];
			for (int i = 0 ; i < roleEnums.Length ; i++)
			{
				roles[i] = roleEnums[i];
			}
			return roles;
		}

		/// <summary>
		/// Converts <see cref="Role"/> array to <see cref="RoleEnum"/> array.
		/// </summary>
		/// <param name="roleEnums">The <see cref="Role[]"/> to be converted</param>
		/// <returns>The <see cref="RoleEnum[]"/></returns>
		public static RoleEnum[] RolesToRoleEnums(Role[] roles)
		{
			RoleEnum[] roleEnums = new RoleEnum[roles.Length];
			for (int i = 0 ; i < roles.Length ; i++)
			{
				roleEnums[i] = roles[i];
			}
			return roleEnums;
		}

		/// <summary>
		/// Converts an array of roles into a single string (like those used by attributes)
		/// </summary>
		/// <param name="roles">The roles<see cref="Role[]"/></param>
		/// <returns>The <see cref="string"/></returns>
		public static string ToSingleString(Role[] roles)
		{
			RoleEnum[] roleEnums = RolesToRoleEnums(roles);
			return roleEnums.ToSingleString();
		}

		/// <summary>
		/// Lists all possible Roles.
		/// </summary>
		/// <returns>The <see cref="string[]"/></returns>
		public static string[] ToStrings()
		{
			return Enum.GetNames(typeof(RoleEnum)); ;
		}

		/// <summary>
		/// Lists all mentioned Roles.
		/// </summary>
		/// <param name="roles">The roles<see cref="Role[]"/></param>
		/// <returns>The <see cref="string[]"/></returns>
		public static string[] ToStrings(Role[] roles)
		{
			string[] ret = new string[roles.Length];
			for (int i = 0 ; i < roles.Length ; i++)
			{
				ret[i] = roles[i].ToString();
			}
			return ret;
		}

		/// <summary>
		/// The ToString
		/// </summary>
		/// <returns>The <see cref="string"/></returns>
		public override string ToString()
		{
			return value.GetName();
		}

		/// <summary>
		/// The Parses <see cref="string"/>, providing tolerance for different ways to write them down.
		/// </summary>
		/// <param name="roleName">The <see cref="string"/> name of the role.</param>
		/// <returns>The <see cref="RoleEnum"/></returns>
		private static RoleEnum ParseString(string roleName)
		{
			switch (roleName.ToLower().Trim())
			{
				case "superadmin":
				case "super admin":
					return RoleEnum.SuperAdmin;
				case "admin":
				case "administrator":
					return RoleEnum.Admin;
				case "member":
				case "standart member":
				case "standartmember":
				case "standartuser":
				case "user":
					return RoleEnum.SuperAdmin;
			}
			throw new ArgumentException("invalid Role Name");
		}


		public static implicit operator string(Role role)
		{
			return role.Value.GetName();
		}

		public static implicit operator Role(string roleName)
		{
			return new Role(roleName);
		}

		public static implicit operator RoleEnum(Role role)
		{
			return role.value;
		}

		public static implicit operator Role(RoleEnum role)
		{
			return new Role(role);
		}
	}
}
