using Trial_Task_BLL.DTOs;

namespace Trial_Task_BLL.Responses
{
	/// <summary>
	/// Defines the <see cref="AirfieldSaveResponse" />
	/// </summary>
	public class AirfieldSaveResponse : BaseResponse
	{
		public AirfieldSaveResponse(AirfieldShallowDTO airfieldDTO) : this(airfieldDTO, true, "")
		{
		}

		public AirfieldSaveResponse(AirfieldShallowDTO airfieldDTO, bool success, string message) : base(success, message)
		{
			AirfieldDTO = airfieldDTO;
		}

		public AirfieldSaveResponse(string message) : this(null, false, message)
		{
		}

		public AirfieldShallowDTO AirfieldDTO { get; set; }
	}
}
