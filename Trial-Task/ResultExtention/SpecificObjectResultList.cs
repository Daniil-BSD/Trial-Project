using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Trial_Task_BLL.Responses;

namespace Trial_Task_WEB.ResultExtention
{
	/// <summary>
	/// Type specific <see cref="ObjectResult"/> that is meant to be used to wrap group results (like adding multiple items and getting success/failure on each)
	/// </summary>
	/// <typeparam name="T">Wrapped type</typeparam>
	public partial class SpecificObjectResultList<T> : SpecificObjectResult<IEnumerable<SpecificObjectResultListEntry<T>>>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResultList{T}"/> class with code 500 and message from the exception.
		/// </summary>
		/// <param name="e">The e<see cref="Exception"/></param>
		public SpecificObjectResultList(Exception e) : base(e)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResultList{T}"/> class.
		/// </summary>
		/// <param name="responses">The responses<see cref="IEnumerable{Response{T}}"/></param>
		public SpecificObjectResultList(IEnumerable<Response<T>> responses) : base()// base constructoor is redundant
		{
			var temp = new List<SpecificObjectResultListEntry<T>>();
			foreach (var response in responses)
			{
				temp.Add(new SpecificObjectResultListEntry<T>(response));
			}
			Object = temp;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResultList{T}"/> class from provided entry list.
		/// </summary>
		/// <param name="value">The value<see cref="IEnumerable{SpecificObjectResultListEntry{T}}"/></param>
		public SpecificObjectResultList(IEnumerable<SpecificObjectResultListEntry<T>> value) : base(value)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResultList{T}"/> class identically to <see cref="SpecificObjectResult{T}.SpecificObjectResult(ObjectResult)"/>.
		/// </summary>
		/// <param name="objectResult">The objectResult<see cref="ObjectResult"/></param>
		public SpecificObjectResultList(ObjectResult objectResult) : base(objectResult)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResultList{T}"/> class identically to <see cref="SpecificObjectResult{T}.SpecificObjectResult(string, int)"/>.
		/// </summary>
		/// <param name="message">The message<see cref="string"/></param>
		/// <param name="statusCode">The statusCode<see cref="int"/></param>
		public SpecificObjectResultList(string message, int statusCode) : base(message, statusCode)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificObjectResultList{T}"/> class identically to <see cref="SpecificObjectResult{T}.SpecificObjectResult(string, IStatusCodeActionResult)"/>.
		/// </summary>
		/// <param name="message">The message<see cref="string"/></param>
		/// <param name="status">The status<see cref="IStatusCodeActionResult"/></param>
		public SpecificObjectResultList(string message, IStatusCodeActionResult status) : base(message, status)
		{
		}
	}
}
