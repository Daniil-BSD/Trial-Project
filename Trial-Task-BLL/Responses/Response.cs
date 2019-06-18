using System;
using System.Collections.Generic;
using System.Text;

namespace Trial_Task_BLL.Responses
{
	public class Response<T> : BaseResponse where T: class
	{
		public T Value { get; set; }
			public Response(T value) : this(value, true, "")
			{
			}
			private Response(T value, bool success, string message) : base(success, message)
			{
			Value = value;
			}
			public Response(string message) : this(null, false, message)
			{
			}
		}
}
