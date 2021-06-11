using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	/// <summary>
	/// Provider an interface for accessing nurse model
	/// </summary>
	public interface INurseProvider
	{
		/// <summary>
		/// Nurse details
		/// </summary>
		Nurse Nurse { get; set; }

		/// <summary>
		/// Assigned schedules
		/// </summary>
		List<Schedule> Schedules { get; set; }

		/// <summary>
		/// a list of nurse plicies for this nurse
		/// </summary>
		List<INursePolicy> NursePolicies { get; set; }

		/// <summary>
		/// check if the nurse is available on this schedule
		/// </summary>
		/// <param name="Schedule">schedule</param>
		/// <returns>True/False</returns>
		bool Available(Schedule Schedule);
	}

	public class NurseProvider: INurseProvider
	{
		protected readonly ILogger _logger;

		public NurseProvider(ILogger<NurseProvider> logger)
		{
			_logger = logger;
		}

		public Nurse Nurse { get; set; }
		public List<Schedule> Schedules { get; set; } = new List<Schedule>();
		public List<INursePolicy> NursePolicies { get; set; } = new List<INursePolicy>();

		public bool Available(Schedule Schedule)
		{
			if (Schedule == null)
			{
				throw new SafeException("An invalid schedule detected!");
			}

			//in this code test, no needs to run in parallel
			var results = NursePolicies?.Select(p => p.Pass(Schedule, Schedules)) ?? null;

			return results == null ? true : results.All(r => r);
		}
	}
}
