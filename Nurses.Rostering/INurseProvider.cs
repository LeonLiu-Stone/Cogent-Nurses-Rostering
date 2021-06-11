using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
		Task<bool> Available(Schedule Schedule);
	}

	public class NurseProvider: INurseProvider
	{
		protected readonly ILogger _logger;

		public NurseProvider(ILogger<NurseProvider> logger)
		{
			_logger = logger;
		}

		public Nurse Nurse { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public List<Schedule> Schedules { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public List<INursePolicy> NursePolicies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<bool> Available(Schedule Schedule)
		{
			throw new NotImplementedException();
		}
	}
}
