using System;
using System.Threading.Tasks;
using Xunit;

namespace Nurses.Rostering.Test.OneShiftPerDayNursePolicyTest
{
	public class Pass
	{
		[Fact]
		public void ReturnFalse_WhenWorkOnASameDayTowice()
		{
			Assert.False(true);
		}


		[Fact]
		public void ReturnTrue_WhenNoWorkOnASameDay()
		{
			Assert.False(true);
		}
	}
}
