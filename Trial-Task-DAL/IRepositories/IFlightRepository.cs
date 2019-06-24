using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Enumerations;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	/// <summary>
	/// Defines the <see cref="IFlightRepository" />
	/// </summary>
	public interface IFlightRepository : IRepositoryForGuiDIdentifyables<Flight>
	{
		/// <summary>
		/// Standart Get method for a single <see cref="Flight"/>
		/// </summary>
		/// <param name="id">The <see cref="Guid"/> id.</param>
		/// <returns>The <see cref="Task{Flight}"/></returns>
		Task<Flight> GetAsync(Guid id);

		/// <summary>
		/// Inserts a new <see cref="Flight"/> into the Database.
		/// Note that <see cref="Flight"/> has <see cref="Guid"/>field indecating <see cref="User"/> and includes <see cref="GPSLog"/> which includes multiple <see cref="GPSLogEntry"/>;
		/// all this data is inserted into the respective tables while properly linkingthe references, so <paramref name="flightIn"/> needs to have all those fields valid.
		/// </summary>
		/// <param name="flightIn">The <see cref="Flight"/> to be inserted.</param>
		/// <returns>The same <see cref="Task{Flight}"/>, returned as it was recorded in a database (ID field is now populated)</returns>
		Task<Flight> InsertNewFlight(Flight flightIn);

		/// <summary>
		/// Lists Fully information of all flights in the database.
		/// Practically dumps the database contents, should be removed
		/// </summary>
		/// <returns>The <see cref="Task{List{Flight}}"/></returns>
		[Obsolete("Returns the entire Database, Testing only!")]
		Task<List<Flight>> ListAsync();

		/// <summary>
		/// Lists Basic information of all flights in the Database.
		/// </summary>
		/// <returns>The <see cref="Task{List{Flight}}"/></returns>
		Task<List<Flight>> ListReducedAsync();

		/// <summary>
		/// Sets the Status of the flight to a specified value.
		/// It is an update that ensures that nothing else is modified.
		/// </summary>
		/// <param name="id">The <see cref="Guid"/> id of the Flight to be updated</param>
		/// <param name="status">The new <see cref="EFlightStatus"/>value to be recorded.</param>
		/// <returns>The same <see cref="Task{Flight}"/> after the update</returns>
		Task<Flight> UpdateStatusAsync(Guid id, EFlightStatus status);
	}
}
