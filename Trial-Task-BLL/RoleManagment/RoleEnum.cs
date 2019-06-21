using System.ComponentModel;

namespace Trial_Task_BLL.RoleManagment
{
	/// <summary>
	/// Defines the <see cref="Role" />
	/// </summary>
	partial struct Role
	{
		public enum RoleEnum : byte
		{
			[DisplayName("Super Admin")]
			SuperAddmin = 255,
			[DisplayName("Administrator")]
			Admin = 200,
			[DisplayName("Standart Member")]
			Member = 1
		}
	}
}
