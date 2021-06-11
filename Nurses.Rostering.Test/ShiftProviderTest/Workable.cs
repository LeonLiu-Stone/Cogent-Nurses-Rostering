using System;
using System.Threading.Tasks;
using Xunit;

namespace Nurses.Rostering.Test.ShiftProviderTest
{
	public class Workable
	{
		[Fact]
		public void ReturnFalse_WhenShiftPoliciesFailed()
		{
			Assert.False(true);
		}

		[Fact]
		public void ReturnTrue_WhenShiftPoliciesPassed()
		{
			Assert.False(true);
		}
	}
}
