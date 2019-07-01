using System;
using System.Threading.Tasks;
using AutoMapper;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_DAL.Repositories;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="IGCFileRecordService" />
	/// </summary>
	public class IGCFileRecordService : BaseService, IIGCFileRecordService
	{
		private readonly IFlightService _flightService;

		private readonly IIGCFileRecordRepository _IGCFileRecordRepository;

		private readonly IUserService _userService;

		public IGCFileRecordService(IIGCFileRecordRepository iIGCFileRecordRepository, IFlightService flightService, IUserService userService, IMapper mapper) : base(mapper)
		{
			_IGCFileRecordRepository = iIGCFileRecordRepository;
			_flightService = flightService;
			_userService = userService;
		}

		public Task<Response<IGCFileRecordDTO>> InsertAsync(IGCFileRecordDTO fileRecordDTO)
		{
			return Response<IGCFileRecordDTO>.CatchInvalidOperationExceptionAndMap(
				_IGCFileRecordRepository.InsertAsync(
					_mapper.Map<IGCFileRecordDTO, IGCFileRecord>(fileRecordDTO)
					)
				, _mapper);
		}

		public Task<Response<IGCFileRecordDTO>> InsertAsync(string path)
		{
			var userIDResponse = _userService.GetCurrentUserID();
			if (!userIDResponse.Success)
				return Task.FromResult(new Response<IGCFileRecordDTO>(userIDResponse.Message));
			var fileRecord = new IGCFileRecordDTO()
			{
				UserID = userIDResponse.Value,
				FilePath = path
			};
			return InsertAsync(fileRecord);
		}

		/// <summary>
		/// This is a basic implementation, lacking dynamic error handeling.
		/// </summary>
		/// <returns>true</returns>
		public async Task ProcessAllFiles()
		{
			IGCFileRecord[] unprocessedFiles = (await _IGCFileRecordRepository.GetListOfFiles()).ToArray();
			var length = unprocessedFiles.Length;
			Response<FlightDTO>[] tasks = new Response<FlightDTO>[length];

			Console.WriteLine("============================================================");
			Console.WriteLine("Processing Started! " + length.ToString() + " flights in queue!");
			Console.WriteLine("============================================================");
			for (int i = 0 ; i < length ; i++)
			{
				tasks[i] = await _flightService.ParseIGCFile(unprocessedFiles[i].FilePath, unprocessedFiles[i].UserID);
				// task[i] represents result of processing unprocessedFiles[i] so logging or error handeling logic should go here
				try
				{
					System.IO.File.Delete(unprocessedFiles[i].FilePath);
				}
				finally
				{
					await _IGCFileRecordRepository.DeleteAsync(unprocessedFiles[i]);
				}
			}
			Console.WriteLine("============================================================");
			Console.WriteLine("Processing Complete! " + length.ToString() + " flights added!");
			Console.WriteLine("============================================================");
		}
	}
}
