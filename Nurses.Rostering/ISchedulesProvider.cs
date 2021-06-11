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
		void Initialise(DateTime startDate, DateTime endDate);
	}

	public class SchedulesProvider : ISchedulesProvider
	{
		protected readonly ILogger _logger;
		protected readonly IShiftsProvider _shiftsProvider;
		private List<Schedule> _schedules = new List<Schedule>(); 

		public SchedulesProvider(
			ILogger<RandamPickupService> logger,
			IShiftsProvider shiftsProvider)
		{
			_logger = logger;
			_shiftsProvider = shiftsProvider;
		}

		public List<Schedule> GetAll()
		{
			return _schedules;
		}

		public void Initialise(DateTime startDate, DateTime endDate)
		{
			var shifts = _shiftsProvider.GetAll();
			_schedules = GetDates(startDate, endDate)
				.SelectMany(d => shifts.Select(s => new Schedule(d, s.Shift)))
				.ToList();

			List<DateTime> GetDates(DateTime startDate, DateTime endDate) =>
			Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
				.Select(offset => startDate.AddDays(offset))
				.ToList();
		}
	}
}
