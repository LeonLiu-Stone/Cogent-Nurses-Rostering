using System;
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
		Task<Nurse> Pickup(Schedule Schedule);
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

		public Task<Nurse> Pickup(Schedule Schedule)
		{
			throw new NotImplementedException();
		}
	}
}
