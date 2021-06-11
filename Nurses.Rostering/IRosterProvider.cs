using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	public interface IRosterProvider
	{
		/// <summary>
		/// Generate nurse roster
		/// </summary>
		/// <returns>list of roster</returns>
		List<Job> Generate();
	}

	public class RosterProvider : IRosterProvider
	{
		protected readonly ILogger _logger;
		protected readonly ISchedulesProvider _schedulesProvider; 
		protected readonly INursesProvider _nursesProvider;
		protected readonly IPickupService _pickupService;
		protected readonly IShiftsProvider _shiftsProvider;

		public RosterProvider(
			ILogger logger,
			ISchedulesProvider schedulesProvider,
			INursesProvider nursesProvider,
			IShiftsProvider shiftsProvider,
			IPickupService pickupService)
		{
			_logger = logger;
			_schedulesProvider = schedulesProvider;
			_nursesProvider = nursesProvider;
			_pickupService = pickupService;
			_shiftsProvider = shiftsProvider;
		}

		public List<Job> Generate()
		{
			var nurseProviders = _nursesProvider.GetAll();
			var shiftProviders = _shiftsProvider.GetAll();
			var jobs = _schedulesProvider
				.GetAll() // all schedule(date,shift)
				.SelectMany(s =>
					GetOnDutyNursesForShift(s, nurseProviders, shiftProviders)
					.Select(nurse => new Job(s, nurse))
				)
				.ToList();

			return jobs;
		}

		/// <summary>
		/// return on-duty nurses for this schedule
		/// </summary>
		/// <param name="schedule">shedule</param>
		/// <param name="nurseProviders">all nurses</param>
		/// <param name="shiftProviders">all shfits</param>
		/// <returns>on-duty nurses</returns>
		private List<Nurse> GetOnDutyNursesForShift(
			Schedule schedule,
			List<INurseProvider> nurseProviders,
			List<IShiftProvider> shiftProviders)
		{
			var shiftProvider = shiftProviders.FirstOrDefault(sp => sp.Shift.Name == schedule.Shift.Name);
			var onDutyNurses = new List<Nurse>();

			//loop when not all nurses added
			while (onDutyNurses.Count <= nurseProviders.Count)
			{
				var nurse = _pickupService.Pickup(schedule, nurseProviders);
				onDutyNurses.Add(nurse);

				//update selected nurse's schedules
				var selectedNurse = nurseProviders.FirstOrDefault(np => np.Nurse.Uid == nurse.Uid);
				selectedNurse.Schedules.Add(schedule);

				//jump out when shift is workable
				if (shiftProvider.Workable(onDutyNurses)) { break; }
			}

			return onDutyNurses;
		}
	}
}
