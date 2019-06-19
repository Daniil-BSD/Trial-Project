using System;
using System.Threading.Tasks;
using AutoMapper;

namespace Trial_Task_BLL.Responses
{
	/// <summary>
	/// Defines the <see cref="Response{T}" />
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Response<T> : BaseResponse
	{
		public Response(BaseResponse baseResponse) : base(false, baseResponse.Message, baseResponse.NotFoundFlag)
		{
			if (baseResponse.Success)
			{
				throw new ArithmeticException("Can only convert unsecsessful responses.");
			}
		}

		public Response(string message, bool notFoundFlag = false) : base(false, message, notFoundFlag)
		{
		}

		public Response(T value) : this(value, true, "", false)
		{
		}

		protected Response(T value, bool success, string message, bool notFoundFlag) : base(success, message, notFoundFlag)
		{
			Value = value;
		}

		public T Value { get; set; }

		public static async Task<Response<T>> CatchInvalidOperationException(Task<T> getTask)
		{
			try
			{
				return new Response<T>(await getTask);
			}
			catch (InvalidOperationException e)
			{
				return new Response<T>(e.Message, true);
			}
			catch (Exception e)
			{
				return new Response<T>(e.Message);
			}
		}

		public static async Task<Response<T>> CatchInvalidOperationExceptionAndMap<T2>(Task<T2> getTask, IMapper mapper)
		{
			try
			{
				return new Response<T>(mapper.Map<T2, T>(await getTask));
			}
			catch (InvalidOperationException e)
			{
				return new Response<T>(e.Message, true);
			}
			catch (Exception e)
			{
				return new Response<T>(e.Message);
			}
		}
	}
}
