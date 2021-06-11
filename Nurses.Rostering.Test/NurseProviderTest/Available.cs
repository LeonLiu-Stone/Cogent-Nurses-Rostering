using System;
using System.Threading.Tasks;
using Xunit;

namespace Nurses.Rostering.Test.NurseProviderTest
{
	public class Available
	{
		[Fact]
		public void ReturnFalse_WhenNursePoliciesFailed()
		{
			Assert.False(true);
		}

		[Fact]
		public void ReturnTrue_WhenNursePoliciesPassed()
		{
			Assert.False(true);
		}
	}
}
