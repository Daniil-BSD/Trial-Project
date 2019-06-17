using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Trial_Task_WEB.ResultExtention
{
	public class SpecificObjectResult<T> : ObjectResult
	{
		public SpecificObjectResult(T value) : base(value) { }

		public SpecificObjectResult(object value, int statusCode) : base(value)
		{
			StatusCode = statusCode;
		}
		public SpecificObjectResult(ObjectResult objectResult) : base(objectResult.Value)
		{
			if (StatusCode == 200 && !typeof(T).Equals(Value.GetType()))
			{
				StatusCode = 400;
				Value = "Type Mismatch";
			}
			else{
				StatusCode = objectResult.StatusCode;
			}
		}

		public T Object
		{
			get {
				if (StatusCode == 200)
					return (T)this.Value;
				throw new NullReferenceException();
			}
		}
	}
}
