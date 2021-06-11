using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	public interface IShiftsProvider
	{
		Task<List<IShiftProvider>> GetAll();

		Task Add(Shift shift);
	}

	public class ShiftsProvider : IShiftsProvider
	{
		protected readonly ILogger _logger;

		public ShiftsProvider(ILogger<ShiftsProvider> logger)
		{
			_logger = logger;
		}

		public Task Add(Shift shift)
		{
			throw new NotImplementedException();
		}

		public Task<List<IShiftProvider>> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
