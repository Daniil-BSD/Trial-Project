using Trial_Task_BLL.Responses;

namespace Trial_Task_WEB.ResultExtention
{
	/// <summary>
	/// Defines the <see cref="SpecificObjectResultListEntry{T}" />
	/// This class is Very similar to the responce, but it is implemented  separatly such that editing it, or the ResponseBase, sill not change the other
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SpecificObjectResultListEntry<T>
	{
		public SpecificObjectResultListEntry(Response<T> response) : this(response.Value, response.Success, response.Message)
		{
		}

		public SpecificObjectResultListEntry(string message) : this(false, message)
		{
		}

		public SpecificObjectResultListEntry(T value) : this(value, true, "")
		{
		}

		protected SpecificObjectResultListEntry(bool success, string message)
		{
			Success = success;
			Message = message;
		}

		protected SpecificObjectResultListEntry(T value, bool success, string message) : this(success, message)
		{
			Value = value;
			Success = success;
			Message = message;
		}

		public string Message { get; protected set; }

		public bool Success { get; protected set; }

		public T Value { get; set; }
	}
}
