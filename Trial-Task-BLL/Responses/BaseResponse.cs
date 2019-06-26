namespace Trial_Task_BLL.Responses
{
	/// <summary>
	/// Defines basic properties of a response.
	/// </summary>
	public abstract class BaseResponse
	{
		/// <summary>
		/// Gets or sets the Message of the response, in case of faliure
		/// </summary>
		public string Message { get; protected set; }

		/// <summary>
		/// Gets or sets a value indicating whether the reason for failure is the target of the request not being found(if false could mean something different happend)
		/// </summary>
		public bool NotFoundFlag { get; protected set; }

		/// <summary>
		/// Gets or sets a value indicating whether Success
		/// Indecates if the request was sucessful.
		/// </summary>
		public bool Success { get; protected set; }

		/// <summary>
		/// Gets or sets the Value
		/// </summary>
		public virtual object Value { get; protected set; }

		protected BaseResponse(object value, bool success, string message, bool notFoundFlag)
		{
			Value = value;
			Success = success;
			Message = message;
			NotFoundFlag = !success && notFoundFlag;
		}
	}
}
