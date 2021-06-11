using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nurses.Rostering.Models;

namespace Nurses.Rostering
{

	public interface IShiftPolicy
	{
		bool Pass(Shift shift, List<Nurse> nurses);
	}

	/// <summary>
	/// Five nurses need to be on staff for each shift.
	/// </summary>
	public class FiveNursesNeedPerShiftPolicy : IShiftPolicy
	{
		//Todo: get it from settings
		const int DefaultNursesPerShift = 5;

		protected readonly ILogger _logger;

		public FiveNursesNeedPerShiftPolicy(ILogger logger)
		{
			_logger = logger;
		}

		public bool Pass(Shift shift, List<Nurse> nurses)
		{
			if (shift == null)
			{
				throw new SafeException("An invalid shift detected!");
			}

			return nurses?.Count() >= DefaultNursesPerShift ? true : false;
		}
	}
}
