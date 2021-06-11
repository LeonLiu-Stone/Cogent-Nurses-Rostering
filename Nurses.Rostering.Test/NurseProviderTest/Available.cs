using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nurses.Rostering.Models;
using Xunit;

namespace Nurses.Rostering.Test.NurseProviderTest
{
	public class Available
	{
		[Fact]
		public void ReturnFalse_WhenNursePoliciesFailed()
		{
			//Arrange
			var nurse = new Nurse("111111", "Lei");
			var schedule = new Schedule(DateTime.Now, "Morning");
			var schedules = new List<Schedule>() {
				new Schedule(DateTime.Now, "Night"),
				new Schedule(DateTime.Now.AddDays(1), "Night")
			};
			var policies = new List<INursePolicy>() {
				new OneShiftPerDayNursePolicy(StubHelper.StubILogger<OneShiftPerDayNursePolicy>().Object)
			};

			var testedService = new NurseProvider(nurse);
			testedService.Schedules = schedules;
			testedService.NursePolicies = policies;

			//Act
			var result = testedService.Available(schedule);

			//Assert
			Assert.False(result);
		}

		[Fact]
		public void ReturnTrue_WhenNursePoliciesPassed()
		{
			//Arrange
			var nurse = new Nurse("111111", "Lei");
			var schedule = new Schedule(DateTime.Now, "Morning");
			var schedules = new List<Schedule>() {
				new Schedule(DateTime.Now.AddDays(1), "Night")
			};
			var policies = new List<INursePolicy>() {
				new OneShiftPerDayNursePolicy(StubHelper.StubILogger<OneShiftPerDayNursePolicy>().Object)
			};

			var testedService = new NurseProvider(nurse);
			testedService.Schedules = schedules;
			testedService.NursePolicies = policies;

			//Act
			var result = testedService.Available(schedule);

			//Assert
			Assert.True(result);
		}


		[Fact]
		public void ReturnTrue_WhenNoNursePoliciesDefined()
		{
			//Arrange
			var nurse = new Nurse("111111", "Lei");
			var schedule = new Schedule(DateTime.Now, "Morning");
			var schedules = new List<Schedule>() {
				new Schedule(DateTime.Now.AddDays(1), "Night")
			};
			List<INursePolicy>policies = null;

			var stubILogger = StubHelper.StubILogger<NurseProvider>();

			var testedService = new NurseProvider(nurse);
			testedService.Schedules = schedules;
			testedService.NursePolicies = policies;

			//Act
			var result = testedService.Available(schedule);

			//Assert
			Assert.True(result);
		}
	}
}
