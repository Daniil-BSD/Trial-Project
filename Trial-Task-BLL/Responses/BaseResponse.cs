namespace Trial_Task_BLL.Responses
{
	/*
	 * Responce classes are meant for proper communication between BLL and WEB.
	 * Its purbuse is to have a message or the value of a respective type.
	 * Could be replaced with SpecificObjectResult, but would imply using Status Codes in BLL.
	 */
	public abstract class BaseResponse
	{
		public bool Success { get; protected set; }
		public string Message { get; protected set; }

		public BaseResponse(bool success, string message)
		{
			Success = success;
			Message = message;
		}
	}
}
