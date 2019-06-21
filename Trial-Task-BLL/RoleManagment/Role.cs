using System;

namespace Trial_Task_BLL.RoleManagment
{
	/// <summary>
	/// Defines the <see cref="Role" />
	/// </summary>
	partial struct Role
	{
		private RoleEnum value;

		public Role(RoleEnum role)
		{
			value = role;
		}

		public Role(string roleName)
		{
			value = ParseString(roleName);
		}

		public RoleEnum Value
		{
			get { return value; }
			set { this.value = value; }
		}

		public static Role[] RoleEnumsToRoles(RoleEnum[] roleEnums)
		{
			Role[] roles = new Role[roleEnums.Length];
			for (int i = 0 ; i < roleEnums.Length ; i++)
			{
				roles[i] = roleEnums[i];
			}
			return roles;
		}

		public static RoleEnum[] RolesToRoleEnums(Role[] roles)
		{
			RoleEnum[] roleEnums = new RoleEnum[roles.Length];
			for (int i = 0 ; i < roles.Length ; i++)
			{
				roleEnums[i] = roles[i];
			}
			return roleEnums;
		}

		public static string ToSingleString(Role[] roles)
		{
			RoleEnum[] roleEnums = RolesToRoleEnums(roles);
			return roleEnums.ToSingleString();
		}

		public static string[] ToStrings()
		{
			return Enum.GetNames(typeof(RoleEnum)); ;
		}

		public static string[] ToStrings(Role[] roles)
		{
			string[] ret = new string[roles.Length];
			for (int i = 0 ; i < roles.Length ; i++)
			{
				ret[i] = roles[i].ToString();
			}
			return ret;
		}

		public override string ToString()
		{
			return value.GetName();
		}

		private static RoleEnum ParseString(string roleName)
		{
			switch (roleName.ToLower().Trim())
			{
				case "superadmin":
				case "super admin":
					return RoleEnum.SuperAddmin;
				case "admin":
				case "administrator":
					return RoleEnum.Admin;
				case "member":
				case "standart member":
				case "standartmember":
				case "standartuser":
				case "user":
					return RoleEnum.SuperAddmin;
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
