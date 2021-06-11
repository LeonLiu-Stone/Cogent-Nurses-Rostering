using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	public interface IShiftPolicy
	{
		Task<bool> Pass(Shift shift, List<Nurse> nurses);
	}

	/// <summary>
	/// Five nurses need to be on staff for each shift.
	/// </summary>
	public class FiveNursesNeedPerShiftPolicy : IShiftPolicy
	{
		protected readonly ILogger _logger;

		public FiveNursesNeedPerShiftPolicy(ILogger<FiveNursesNeedPerShiftPolicy> logger)
		{
			_logger = logger;
		}

		public Task<bool> Pass(Shift shift, List<Nurse> nurses)
		{
			throw new NotImplementedException();
		}
	}
}
