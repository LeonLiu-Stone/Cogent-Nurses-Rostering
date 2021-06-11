﻿using System;
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
		List<INurseProvider> GetAll();

		/// <summary>
		/// Register a new nurse to list
		/// </summary>
		/// <param name="nurse">nurse details</param>
		/// <returns></returns>
		void Enroll(Nurse nurse);
	}

	public class NursesProvider : INursesProvider
	{
		protected readonly ILogger _logger;
		private List<INurseProvider> _nursesProviders = new List<INurseProvider>();

		public NursesProvider(ILogger<NursesProvider> logger)
		{
			_logger = logger;
		}

		public void Enroll(Nurse nurse)
		{
			_nursesProviders.Add(new NurseProvider(nurse));
		}

		public List<INurseProvider> GetAll()
		{
			return _nursesProviders;
		}
	}
}
