namespace Trial_Task_BLL.Responses
{
	/// <summary>
	/// Defines the <see cref="ResponseString" />
	/// </summary>
	public class ResponseString : Response<string>
	{
		public ResponseString(string str, bool success, bool notFoundFlag = false) : this(str, false, str, notFoundFlag)
		{
			if (success)
				Message = null;
			else
				Value = null;
		}

		public ResponseString(string value) : this(value, true, "", false)
		{
		}

		protected ResponseString(string value, bool success, string message, bool notFoundFlag) : base(value, success, message, notFoundFlag)
		{
		}
	}
}
