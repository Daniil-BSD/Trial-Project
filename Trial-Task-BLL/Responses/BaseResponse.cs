namespace Trial_Task_BLL.Responses
{
	/// <summary>
	/// Defines the <see cref="BaseResponse" />
	/// </summary>
	public abstract class BaseResponse
	{
		protected BaseResponse(bool success, string message, bool notFoundFlag)
		{
			Success = success;
			Message = message;
			NotFoundFlag = !success && notFoundFlag;
		}

		public string Message { get; protected set; }

		public bool NotFoundFlag { get; protected set; }

		public bool Success { get; protected set; }
	}
}
