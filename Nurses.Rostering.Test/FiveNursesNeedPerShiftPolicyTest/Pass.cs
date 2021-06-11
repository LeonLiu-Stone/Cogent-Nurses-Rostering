using System;
using System.Threading.Tasks;
using Xunit;

namespace Nurses.Rostering.Test.FiveNursesNeedPerShiftPolicyTest
{
	public class Pass
	{
		[Fact]
		public void ReturnFalse_WhenLessThanFiveNursesOnShift()
		{
			Assert.False(true);
		}


		[Fact]
		public void ReturnTrue_WhenMoreThanFiveNursesOnShift()
		{
			Assert.False(true);
		}
	}
}
