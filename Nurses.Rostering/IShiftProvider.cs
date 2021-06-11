using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	public interface IShiftProvider
	{
		Shift Shift { get; set; }

		List<IShiftPolicy> ShiftPolicies { get; set; }

		Task<bool> Workable(List<Nurse> nurses);
	}

	public class ShiftProvider : IShiftProvider
	{
		protected readonly ILogger _logger;

		public ShiftProvider(ILogger<ShiftProvider> logger)
		{
			_logger = logger;
		}

		public Shift Shift { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public List<IShiftPolicy> ShiftPolicies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task<bool> Workable(List<Nurse> nurses)
		{
			throw new NotImplementedException();
		}
	}
}
