using System;
using System.Collections.Generic;
using System.Linq;
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
		List<Schedule> GetAll();

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

		public List<Schedule> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task Initialise(DateTime startDate, DateTime endDate)
		{
			throw new NotImplementedException();
			//var schedules = GetDates(startDate, endDate)
			//	.SelectMany(d => );

			//List<DateTime> GetDates(DateTime startDate, DateTime endDate) =>
			//Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
			//	.Select(offset => startDate.AddDays(offset))
			//	.ToList();
		}
	}
}
