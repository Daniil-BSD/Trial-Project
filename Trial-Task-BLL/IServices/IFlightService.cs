using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.Responses;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IFlightService" />
	/// </summary>
	public interface IFlightService
	{
		/// <summary>
		/// The Getter for the full flight information.
		/// </summary>
		/// <param name="id">The id<see cref="Guid"/></param>
		/// <returns>The <see cref="Task{Response{FlightDTO}}"/></returns>
		Task<Response<FlightDTO>> GetAsync(Guid id);

		/// <summary>
		/// The Getter for the flight information
		/// </summary>
		/// <param name="id">The id<see cref="Guid"/></param>
		/// <returns>The <see cref="Task{Response{FlightBasicDTO}}"/></returns>
		Task<Response<FlightBasicDTO>> GetBasicAsync(Guid id);

		/// <summary>
		/// The Getter for the List of all fllights
		/// </summary>
		/// <returns>The <see cref="Task{List{FlightBasicDTO}}"/></returns>
		Task<List<FlightBasicDTO>> ListReducedAsync();

		/// <summary>
		/// The ParseIGCFile
		/// </summary>
		/// <param name="path">The path<see cref="string"/></param>
		/// <returns>The <see cref="Task{Response{FlightDTO}}"/></returns>
		Task<Response<FlightDTO>> ParseIGCFile(string path);

		/// <summary>
		/// The ParseIGCFile
		/// </summary>
		/// <param name="path">The path<see cref="string"/></param>
		/// <param name="userID">The userID<see cref="Guid"/></param>
		/// <returns>The <see cref="Task{Response{FlightDTO}}"/></returns>
		Task<Response<FlightDTO>> ParseIGCFile(string path, Guid userID);

		/// <summary>
		/// The UpdaateStatus
		/// </summary>
		/// <param name="flightStatusUpdateDTO">The flightStatusUpdateDTO<see cref="FlightStatusUpdateDTO"/></param>
		/// <returns>The <see cref="Task{Response{FlightBasicDTO}}"/></returns>
		Task<Response<FlightBasicDTO>> UpdaateStatus(FlightStatusUpdateDTO flightStatusUpdateDTO);
	}
}
