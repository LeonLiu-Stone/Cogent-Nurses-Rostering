using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	/// <summary>
	/// A common interface for nurse policies
	/// </summary>
	public interface INursePolicy
	{
		/// <summary>
		/// Check whethere the nurse could work on the new schedule
		/// </summary>
		/// <param name="newSchedule">a schedule which the nurse will work on</param>
		/// <param name="schedules">Enrolled Schedules</param>
		/// <returns>True/False</returns>
		Task<bool> Pass(Schedule newSchedule, List<Schedule> schedules);
	}

	/// <summary>
	/// Nurses must not be expected to work more than one shift per day
	/// </summary>
	public class OneShiftPerDayNursePolicy: INursePolicy
	{
		protected readonly ILogger _logger;

		public OneShiftPerDayNursePolicy(ILogger<OneShiftPerDayNursePolicy> logger)
		{
			_logger = logger;
		}

		public Task<bool> Pass(Schedule newSchedule, List<Schedule> schedules)
		{
			throw new NotImplementedException();
		}
	}
}
