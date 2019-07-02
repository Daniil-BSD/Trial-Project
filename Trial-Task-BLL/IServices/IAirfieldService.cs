using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.Responses;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IAirfieldService" />
	/// </summary>
	public interface IAirfieldService
	{
		/// <summary>
		/// The Getter for full Airfield information.
		/// </summary>
		/// <param name="id">The <see cref="Guid"/> id of the Airfield that needs to be returned</param>
		/// <returns>The <see cref="Task{Response{AirfieldDTO}}"/></returns>
		Task<Response<AirfieldDTO>> GetAsync(Guid id);

		/// <summary>
		/// Returns the id of the airfield, whose coordinates have been provided.
		/// (Make sure to check that the response has Sucess set to true)
		/// </summary>
		/// <param name="globalPoint">An object implementing <see cref="IGlobalPoint"/></param>
		/// <returns>The <see cref="Task{Response{Guid}}"/> of the airfield.</returns>
		Task<Response<Guid>> GetLocalAirfieldID(IGlobalPoint globalPoint);

		/// <summary>
		/// The Getter for airfield information.
		/// </summary>
		/// <param name="id">The id<see cref="Guid"/></param>
		/// <returns>The <see cref="Task{Response{AirfieldShallowDTO}}"/></returns>
		Task<Response<AirfieldShallowDTO>> GetShallowAsync(Guid id);

		/// <summary>
		/// The Getter for the List of all airfields and basic information of logs mentioning each.
		/// </summary>
		/// <returns>The <see cref="Task{List{AirfieldDTO}}"/></returns>
		Task<List<AirfieldDTO>> ListAsync();

		/// <summary>
		///  The Getter for the List of Airfields
		/// </summary>
		/// <returns>The <see cref="Task{List{AirfieldShallowDTO}}"/></returns>
		Task<List<AirfieldShallowDTO>> ListShallowAsync();

		/// <summary>
		/// The ParseXLSXFile reads xlsx file with a specific layout and adds the airfields to the databases.
		/// </summary>
		/// <param name="path">The path<see cref="string"/></param>
		/// <returns>The <see cref="Task{IEnumerable{Response{AirfieldShallowDTO}}}"/></returns>
		Task<IEnumerable<Response<AirfieldShallowDTO>>> ParseXLSXFile(string path);

		/// <summary>
		/// A simple method for adding a new airfield. Performs the miniimum distance check.
		/// </summary>
		/// <param name="airfieldSaveDTO">The airfieldSaveDTO<see cref="AirfieldSaveDTO"/></param>
		/// <returns>The <see cref="Task{Response{AirfieldShallowDTO}}"/></returns>
		Task<Response<AirfieldShallowDTO>> SaveAsync(AirfieldSaveDTO airfieldSaveDTO);
	}
}
