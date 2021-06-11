using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Nurses.Rostering.Models;

namespace Nurses.Rostering
{
	public interface IShiftProvider
	{
		Shift Shift { get; set; }

		List<IShiftPolicy> ShiftPolicies { get; set; }

		bool Workable(List<Nurse> nurses);
	}

	public class ShiftProvider : IShiftProvider
	{
		public ShiftProvider(Shift shift)
		{
			Shift = shift;
		}

		public Shift Shift { get; set; }
		public List<IShiftPolicy> ShiftPolicies { get; set; } = new List<IShiftPolicy>();

		public bool Workable(List<Nurse> nurses)
		{
			var results = ShiftPolicies?.Select(p => p.Pass(Shift, nurses)) ?? null;

			return results == null ? true : results.All(r => r);
		}
	}
}
