using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	/// <summary>
	/// Provider an interface for accessing nurses data
	/// </summary>
	public interface INursesProvider
	{
		/// <summary>
		/// Returns all nurses
		/// </summary>
		/// <returns>a list of nurses providers</returns>
		Task<List<INursesProvider>> GetAll();

		/// <summary>
		/// Register a new nurse to list
		/// </summary>
		/// <param name="nurse">nurse details</param>
		/// <returns></returns>
		Task Enroll(Nurse nurse);
	}

	public class NursesProvider : INursesProvider
	{
		protected readonly ILogger _logger;

		public NursesProvider(ILogger<NursesProvider> logger)
		{
			_logger = logger;
		}

		public Task Enroll(Nurse nurse)
		{
			throw new NotImplementedException();
		}

		public Task<List<INursesProvider>> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
