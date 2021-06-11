using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	/// <summary>
	/// Provider an interface for nurse pickup services
	/// </summary>
	public interface IPickupService
	{
		/// <summary>
		/// Return a valid nurse on the schedule
		/// </summary>
		/// <param name="Schedule">schedule</param>
		/// <returns>nurse</returns>
		Nurse Pickup(Schedule schedule, List<INurseProvider> nurseProviders);
	}

	public class RandamPickupService : IPickupService
	{
		protected readonly ILogger _logger;

		public RandamPickupService(
			ILogger<RandamPickupService> logger)
		{
			_logger = logger;
		}

		public Nurse Pickup(Schedule schedule, List<INurseProvider> nurseProviders)
		{
			//Clone a new nurse list
			var nurses = new List<INurseProvider>(nurseProviders);

			//var selectedNurse = nurses.FirstOrDefault(n => n.Available(schedule))
			INurseProvider selectedNurse;
			do
			{
				if (!nurses.Any()) {
					throw new SafeException("No nurse is available on this schedule");
				}

				selectedNurse = ReturnANurse(nurses);
				nurses.Remove(selectedNurse);
			} while (!selectedNurse.Available(schedule));


			return selectedNurse.Nurse;
		}

		private INurseProvider ReturnANurse(List<INurseProvider> nurseProviders)
		{
			// Todo: should move out from this method
			var rand = new Random();
			int rInt = rand.Next(0, nurseProviders.Count - 1);
			return nurseProviders[rInt];
		}
	}
}
