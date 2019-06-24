using System.ComponentModel;

namespace Trial_Task_BLL.RoleManagment
{
	/// <summary>
	/// <see cref="RoleEnum"/> wrapper.
	/// </summary>
	partial struct Role
	{
		/// <summary>
		/// List of Roles as Enum
		/// </summary>
		public enum RoleEnum : byte
		{
			/// <summary>
			/// Defines the SuperAddmin Role.
			/// </summary>
			[DisplayName("Super Admin")]
			SuperAddmin = 255,

			/// <summary>
			/// Defines the Admin Role.
			/// </summary>
			[DisplayName("Administrator")]
			Admin = 200,

			/// <summary>
			/// Defines the Member Role.
			/// </summary>
			[DisplayName("Standart Member")]
			Member = 1
		}
	}
}
