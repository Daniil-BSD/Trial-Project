using System;
using System.Threading.Tasks;
using AutoMapper;

namespace Trial_Task_BLL.Responses
{
	/// <summary>
	/// Defines the <see cref="Response{T}" />
	/// </summary>
	/// <typeparam name="T">Wrapped type</typeparam>
	public class Response<T> : BaseResponse
	{
		/// <summary>
		/// Gets or sets the Value
		/// </summary>
		public new T Value
		{
			get { return (T)base.Value; }
			protected set { base.Value = value; }
		}

		public Response(BaseResponse baseResponse) : base(baseResponse.Value, baseResponse.Success, baseResponse.Message, baseResponse.NotFoundFlag)
		{
			if (baseResponse.Success && !baseResponse.Value.GetType().Equals(Value.GetType()))
			{
				Success = false;
				throw new ArithmeticException("Can only convert unsecsessful responses or sucessful responsces of campatible types.");
			}
		}

		public Response(string message, bool notFoundFlag = false) : base(null, false, message, notFoundFlag)
		{
		}

		public Response(T value) : base(value, true, "", false)
		{
		}

		public Response(T value, bool success, string message, bool notFoundFlag) : base(value, success, message, notFoundFlag)
		{
		}

		/// <summary>
		/// The CatchInvalidOperationException is a method designed to work with Get methods that use method
		/// <see cref="Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.SingleAsync{TSource}(System.Linq.IQueryable{TSource}, System.Linq.Expressions.Expression{Func{TSource, bool}}, System.Threading.CancellationToken)"/>
		/// to catch exception thrown when target of the request was not found and generate approprite state.
		/// Practically this method returns the response with notFoundFlag set to true if the <paramref name="getTask"/> thrown <see cref="InvalidCastException"/>.
		/// and message containing the exception,s message.
		/// </summary>
		/// <param name="getTask">The <see cref="Task{T}"/> that returns the value that should be wrapped in a response</param>
		/// <returns>The <see cref="Task{Response{T}}"/></returns>
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

		/// <summary>
		/// The CatchInvalidOperationExceptionAndMap is an extention oof <see cref="CatchInvalidOperationException(Task{T})"/>, it includes automapping.
		/// This method is mapping getter's return type to the type T using provided <see cref="IMapper"/>; 
		/// note that mapper needs to contain the resulted mapping profile.
		/// </summary>
		/// <typeparam name="T2">Type of a Getter Task, usually Class from the Model</typeparam>
		/// <param name="getTask">The <see cref="Task{T2}"/> that returns the value that should be mapped and wrapped in a response</param>
		/// <param name="mapper">The <see cref="IMapper"/> that should contain the mapping of T2 to T</param>
		/// <returns>The <see cref="Task{Response{T}}"/></returns>
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
