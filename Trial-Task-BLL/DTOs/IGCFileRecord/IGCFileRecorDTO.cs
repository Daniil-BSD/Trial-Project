using System;
using System.ComponentModel.DataAnnotations;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="IGCFileRecordDTO" />
	/// </summary>
	public class IGCFileRecordDTO
	{
		[Required]
		public string FilePath { get; set; }

		[Required]
		public Guid UserID { get; set; }
	}
}
