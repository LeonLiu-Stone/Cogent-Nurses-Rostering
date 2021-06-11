using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nurses.Rostering.Models;
using Xunit;

namespace Nurses.Rostering.Test.OneShiftPerDayNursePolicyTest
{
	public class Pass
	{
		[Fact]
		public void ReturnFalse_WhenWorkOnASameDayTowice()
		{
			//Arrange
			var newSchedule = new Schedule(DateTime.Now, "Morning");
			var schedules = new List<Schedule>() {
				new Schedule(DateTime.Now, "Night"),
				new Schedule(DateTime.Now.AddDays(1), "Night")
			};

			var stubILogger = StubHelper.StubILogger<OneShiftPerDayNursePolicy>();

			var testedService = new OneShiftPerDayNursePolicy(
				stubILogger.Object);

			//Act
			var result = testedService.Pass(newSchedule, schedules);

			//Assert
			Assert.False(result);
		}


		[Fact]
		public void ReturnTrue_WhenNoWorkOnASameDay()
		{
			//Arrange
			var newSchedule = new Schedule(DateTime.Now, "Morning");
			var schedules = new List<Schedule>() {
				new Schedule(DateTime.Now.AddDays(1), "Night")
			};

			var stubILogger = StubHelper.StubILogger<OneShiftPerDayNursePolicy>();

			var testedService = new OneShiftPerDayNursePolicy(
				stubILogger.Object);

			//Act
			var result = testedService.Pass(newSchedule, schedules);

			//Assert
			Assert.True(result);
		}


		[Fact]
		public void ReturnTrue_WhenNoSchedulesYet()
		{
			//Arrange
			var newSchedule = new Schedule(DateTime.Now, "Morning");
			List<Schedule> schedules = null;

			var stubILogger = StubHelper.StubILogger<OneShiftPerDayNursePolicy>();

			var testedService = new OneShiftPerDayNursePolicy(
				stubILogger.Object);

			//Act
			var result = testedService.Pass(newSchedule, schedules);

			//Assert
			Assert.True(result);
		}
	}
}
