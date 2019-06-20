using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Trial_Task_BLL.Responses;

namespace Trial_Task_WEB.ResultExtention
{
	/// <summary>
	/// Defines the <see cref="SpecificObjectResultList{T}" />
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public partial class SpecificObjectResultList<T> : SpecificObjectResult<IEnumerable<SpecificObjectResultListEntry<T>>>
	{
		public SpecificObjectResultList(Exception e) : base(e)
		{
		}

		public SpecificObjectResultList(IEnumerable<Response<T>> responses) : base()// base constructoor is redundant
		{
			var temp = new List<SpecificObjectResultListEntry<T>>();
			foreach (var response in responses)
			{
				temp.Add(new SpecificObjectResultListEntry<T>(response));
			}
			Object = temp;
		}

		public SpecificObjectResultList(IEnumerable<SpecificObjectResultListEntry<T>> value) : base(value)
		{
		}

		public SpecificObjectResultList(ObjectResult objectResult) : base(objectResult)
		{
		}

		public SpecificObjectResultList(string message, int statusCode) : base(message, statusCode)
		{
		}

		public SpecificObjectResultList(string message, IStatusCodeActionResult status) : base(message, status)
		{
		}
	}
}
