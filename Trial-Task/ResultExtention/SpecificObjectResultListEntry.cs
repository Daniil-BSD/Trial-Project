using Trial_Task_BLL.Responses;

namespace Trial_Task_WEB.ResultExtention
{
	/// <summary>
	/// Class used by <see cref="SpecificObjectResultList{T}"/>
	/// This class is Very similar to the <see cref="Response{T}"/>, but it is implemented  separatly such that editing it, or the <see cref="Response{T}"/>, will not change the other.
	/// </summary>
	/// <typeparam name="T">Wrapped type</typeparam>
	public class SpecificObjectResultListEntry<T>
	{
        /// <summary>
		/// Gets or sets the Message of the response, in case of faliure
		/// </summary>
        public string Message { get; protected set; }

		/// <summary>
		/// Gets or sets a value indicating whether Success
		/// Indecates if the request was sucessful.
		/// </summary>
		public bool Success { get; protected set; }

		/// <summary>
		/// Gets or sets the Value
		/// </summary>
		public T Value { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResultListEntry{T}"/> class.
		/// Simply maps <see cref="Response{T}"/> to <see cref="SpecificObjectResultListEntry{T}"/>
		/// </summary>
		/// <param name="response">The response<see cref="Response{T}"/></param>
		public SpecificObjectResultListEntry(Response<T> response) : this(response.Value, response.Success, response.Message)
		{
		}

		/// <summary>
		/// Initiializes a Failure <see cref="SpecificObjectResultListEntry{T}"/> with the specified Message.
		/// </summary>
		/// <param name="message">The message<see cref="string"/></param>
		public SpecificObjectResultListEntry(string message) : this(false, message)
		{
		}

		/// <summary>
		/// Initiializes a Sucess <see cref="SpecificObjectResultListEntry{T}"/> with the specified Value.
		/// </summary>
		/// <param name="value">The value<see cref="T"/></param>
		public SpecificObjectResultListEntry(T value) : this(value, true, "")
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResultListEntry{T}"/> class.
		/// </summary>
		/// <param name="success">The success<see cref="bool"/></param>
		/// <param name="message">The message<see cref="string"/></param>
		protected SpecificObjectResultListEntry(bool success, string message)
		{
			Success = success;
			Message = message;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResultListEntry{T}"/> class.
		/// </summary>
		/// <param name="value">The value<see cref="T"/></param>
		/// <param name="success">The success<see cref="bool"/></param>
		/// <param name="message">The message<see cref="string"/></param>
		protected SpecificObjectResultListEntry(T value, bool success, string message) : this(success, message)
		{
			Value = value;
			Success = success;
			Message = message;
		}
	}
}
