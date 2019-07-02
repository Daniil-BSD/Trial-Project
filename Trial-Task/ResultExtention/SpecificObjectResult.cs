using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Trial_Task_BLL.Responses;

namespace Trial_Task_WEB.ResultExtention
{
	/// <summary>
	/// Type specific <see cref="ObjectResult"/>
	/// </summary>
	/// <typeparam name="T">Wrapped type</typeparam>
	public class SpecificObjectResult<T> : ObjectResult
	{
		public const string NOT_FOUND_MESSAGE_STRING = "Not Found";

		/// <summary>
		/// Gets a value indicating whether <see cref="Object"/> is valid and not null.
		/// </summary>
		public bool NotNull
		{
			get { return StatusCode == 200 && Value != null; }
		}

		/// <summary>
		/// Type specific <see cref="Value"/> that has special behaviours on set and throws <see cref="NullReferenceException"/> if invalid.
		/// </summary>
		[IgnoreDataMember]
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

		/// <summary>
		/// Gets a value indicating whether <see cref="Object"/> is valid. (is iit safe to read <see cref="Object"/>?)
		/// </summary>
		public bool Valid
		{
			get { return StatusCode == 200; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResult{T}"/> class with error 404 content.
		/// </summary>
		public SpecificObjectResult() : this(NOT_FOUND_MESSAGE_STRING, 404)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResult{T}"/> class with code 500 and message from the exception.
		/// </summary>
		/// <param name="e">The e<see cref="Exception"/></param>
		public SpecificObjectResult(Exception e) : this("", 500)
		{
			Value = "Internal Server Error: " + e.Message + "\n" + e.StackTrace;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResult{T}"/> class from an <see cref="ObjectResult"/> while enforsing the type T.
		/// </summary>
		/// <param name="objectResult">The objectResult<see cref="ObjectResult"/></param>
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

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResult{T}"/> class from a matching <see cref="Response{T}"/>
		/// </summary>
		/// <param name="response">The response<see cref="Response{T}"/></param>
		/// <param name="defaultExceptionStatusCode">The <see cref="int"/> code that would be assigned if the result has both flags as false.</param>
		public SpecificObjectResult(Response<T> response, int defaultExceptionStatusCode = 500) : base(response.Value)// base constructoor is redundant
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
					StatusCode = defaultExceptionStatusCode;
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResult{T}"/> class with the provided error Message and code.
		/// </summary>
		/// <param name="message">The message<see cref="string"/></param>
		/// <param name="statusCode">The statusCode (cannot be 200)<see cref="int"/></param>
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

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResult{T}"/> class with the message and a code from the parameters.
		/// </summary>
		/// <param name="message">The message<see cref="string"/></param>
		/// <param name="status"><see cref="IStatusCodeActionResult"/> StatusCode of which will be used</param>
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

		/// <summary>
		/// Initializes a new instance of the success <see cref="SpecificObjectResult{T}"/> class.
		/// </summary>
		/// <param name="value">The value<see cref="T"/></param>
		public SpecificObjectResult(T value) : base(value)
		{
			if (value == null)
			{
				StatusCode = 404;
			} else
			{
				StatusCode = 200;
			}
		}

		/// <summary>
		/// Generate SpecificObjectResult with appropriate <see cref="StatusCode"/>.
		/// </summary>
		/// <param name="message">The message<see cref="string"/></param>
		/// <returns>The <see cref="SpecificObjectResult{T}"/></returns>
		public static SpecificObjectResult<T> InternalServerError(string message)
		{
			return new SpecificObjectResult<T>("Internal Server Error: " + message, 500);
		}

		/// <summary>
		/// Translates Response of a matching type.
		/// </summary>
		/// <param name="response">The response<see cref="Response{T}"/></param>
		/// <returns>The <see cref="SpecificObjectResult{T}"/></returns>
		public static SpecificObjectResult<T> TranslateResponse(Response<T> response)
		{
			if (response.Success)
				return new SpecificObjectResult<T>(response.Value);
			else if (response.NotFoundFlag)
				return new SpecificObjectResult<T>(response.Message, 404);
			else
				return new SpecificObjectResult<T>("Internal Server Error: " + response.Message, 500);
		}
	}
}
