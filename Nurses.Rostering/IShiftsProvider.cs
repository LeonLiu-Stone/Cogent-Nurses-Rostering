using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	public interface IShiftsProvider
	{
		List<IShiftProvider> GetAll();

		void Add(Shift shift);
	}

	public class ShiftsProvider : IShiftsProvider
	{
		protected readonly ILogger _logger;
		private List<IShiftProvider> _shiftsProviders = new List<IShiftProvider>();

		public ShiftsProvider(ILogger logger)
		{
			_logger = logger;
		}

		public void Add(Shift shift)
		{
			var shiftProvider = new ShiftProvider(shift);

			// set OneShiftPerDayNursePolicy as default policy
			// could be dynamically mapping in the future
			shiftProvider.ShiftPolicies.Add(new FiveNursesNeedPerShiftPolicy(_logger));

			_shiftsProviders.Add(shiftProvider);
		}

		public List<IShiftProvider> GetAll()
		{
			return _shiftsProviders;
		}
	}
}
