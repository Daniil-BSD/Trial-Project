using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Trial_Task_BLL.Responses;

namespace Trial_Task_WEB.ResultExtention
{
	/// <summary>
	/// Defines the <see cref="SpecificObjectResult{T}" />
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SpecificObjectResult<T> : ObjectResult
	{
		public const string NOT_FOUND_MESSAGE_STRING = "Not Found";

		public SpecificObjectResult(Exception e) : this("", 500)
		{
			Value = "Internal Server Error: " + e.Message + "\n" + e.StackTrace;
		}

		public SpecificObjectResult(ObjectResult objectResult) : base(objectResult.Value)
		{
			if (StatusCode == 200 && !typeof(T).Equals(Value.GetType()))
			{
				StatusCode = 400;
				Value = "Type Mismatch";
			} else
			{
				StatusCode = objectResult.StatusCode;
			}
		}

		public SpecificObjectResult(Response<T> response) : base(response.Value)// base constructoor is redundant
		{
			if (response.Success)
			{
				Object = response.Value;
			} else
			{
				if (response.NotFoundFlag)
				{
					Value = NOT_FOUND_MESSAGE_STRING;
					StatusCode = 404;
				} else
				{
					Value = response.Message;
					StatusCode = 500;
				}
			}
		}

		public SpecificObjectResult(string message, int statusCode) : base(message)
		{
			if (statusCode != 200)
			{
				StatusCode = statusCode;
			} else
			{
				StatusCode = 500;
			}
		}

		public SpecificObjectResult(string message, IStatusCodeActionResult status) : base(message)
		{
			if (status.StatusCode != 200)
			{
				StatusCode = status.StatusCode;
			} else
			{
				StatusCode = 500;
			}
		}

		public SpecificObjectResult(T value) : base(value)
		{
			if (value == null)
			{
				StatusCode = 404;
			}
		}

		public bool NotNull
		{
			get { return StatusCode == 200 && Value != null; }
		}

		public T Object
		{
			get {
				if (StatusCode == 200)
					return (T)this.Value;
				throw new NullReferenceException();
			}
			set {
				this.Value = value;
				this.StatusCode = 200;
				if (this.Value == null)
				{
					this.StatusCode = 404;
					this.Value = NOT_FOUND_MESSAGE_STRING;
				}
			}
		}

		public bool Valid
		{
			get { return StatusCode == 200; }
		}

		public static SpecificObjectResult<T> InternalServerError(string message)
		{
			return new SpecificObjectResult<T>("Internal Server Error: " + message, 500);
		}

		public static SpecificObjectResult<T> TranslateResponse<T>(Response<T> response)
		{
			if (response.Success)
				return new SpecificObjectResult<T>(response.Value);
			else if (response.NotFoundFlag)
				return new SpecificObjectResult<T>(response.Message, 404);
			else
				return new SpecificObjectResult<T>(response.Message, 500);
		}
	}
}
