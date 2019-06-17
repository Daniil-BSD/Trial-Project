using System;
using Microsoft.AspNetCore.Mvc;

namespace Trial_Task_WEB.ResultExtention
{
	/*
	 * Improvement of a basic ObjuectResult, that allowed easy configuration of status code and a value,
	 * but stored said value as an object.
	 * This class has all benifits of a ObjuectResult (: ActionResult, IStatusCodeActionResult, IActionResult),
	 * but adds property "Object" that returns the specified type.
	 * SpecificObjectResult can copy all ObjectResult propertis of such objects as BadRequestObjectResult or OkObjectResult
	 * as long as the 200 code is passed together with the vlid objeect of type T in the Value.
	 * Also automatically sets StatusCode to 404 (Not found), if (T: value) is null
	 */
	public class SpecificObjectResult<T> : ObjectResult
	{
		public SpecificObjectResult(T value) : base(value)
		{
			if (value == null)
			{
				StatusCode = 404;
			}
		}

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
			} else
			{
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
			set {
				this.Value = value;
				this.StatusCode = 200;
				if (this.Value == null)
				{
					this.StatusCode = 404;
					this.Value = "Not Found";
				}
			}
		}
	}
}
