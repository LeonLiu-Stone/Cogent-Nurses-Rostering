using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	/// <summary>
	/// Provider an interface for accessing schedules
	/// </summary>
	public interface ISchedulesProvider
	{
		/// <summary>
		/// Returns all schedules
		/// </summary>
		/// <returns></returns>
		Task<List<Schedule>> GetAll();

		/// <summary>
		/// Generate schedules by giving data range 
		/// </summary>
		/// <param name="startDate">start date</param>
		/// <param name="endDate">end date</param>
		/// <returns></returns>
		Task Initialise(DateTime startDate, DateTime endDate);
	}

	public class SchedulesProvider : ISchedulesProvider
	{
		protected readonly ILogger _logger;

		public SchedulesProvider(ILogger<RandamPickupService> logger)
		{
			_logger = logger;
		}

		public Task<List<Schedule>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task Initialise(DateTime startDate, DateTime endDate)
		{
			throw new NotImplementedException();
		}
	}
}
