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
		INurseProvider Pickup(Schedule schedule);
	}

	public class RandamPickupService : IPickupService
	{
		protected readonly ILogger _logger;
		protected readonly INursesProvider _nursesProvider;

		public RandamPickupService(
			ILogger<RandamPickupService> logger,
			INursesProvider nursesProvider)
		{
			_logger = logger;
			_nursesProvider = nursesProvider;
		}

		public INurseProvider Pickup(Schedule schedule)
		{
			var nurses = _nursesProvider.GetAll();

			INurseProvider selectedNurse;
			do
			{
				if (!nurses.Any()) {
					throw new SafeException("No nurse is available on this schedule");
				}

				selectedNurse = ReturnANurse(nurses);
				nurses.Remove(selectedNurse);
			} while (!selectedNurse.Available(schedule));


			return selectedNurse;
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
