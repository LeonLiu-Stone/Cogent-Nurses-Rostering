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
			var newSchedule = new Schedule(DateTime.Now, new Shift("Morning"));
			var schedules = new List<Schedule>() {
				new Schedule(DateTime.Now, new Shift("Night")),
				new Schedule(DateTime.Now.AddDays(1), new Shift("Night"))
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
			var newSchedule = new Schedule(DateTime.Now, new Shift("Morning"));
			var schedules = new List<Schedule>() {
				new Schedule(DateTime.Now.AddDays(1), new Shift("Night"))
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
			var newSchedule = new Schedule(DateTime.Now, new Shift("Morning"));
			List<Schedule> schedules = null;

			var stubILogger = StubHelper.StubILogger<OneShiftPerDayNursePolicy>();

			var testedService = new OneShiftPerDayNursePolicy(
				stubILogger.Object);

			//Act
			var result = testedService.Pass(newSchedule, schedules);

			//Assert
			Assert.True(result);
		}

		[Fact]
		public void ThrowException_WhenNewScheduleIsNull()
		{
			//Arrange
			Schedule newSchedule = null;
			List<Schedule> schedules = null;

			var stubILogger = StubHelper.StubILogger<OneShiftPerDayNursePolicy>();

			var testedService = new OneShiftPerDayNursePolicy(
				stubILogger.Object);

			//Act
			Action act = () => testedService.Pass(newSchedule, schedules);

			//Assert
			SafeException exception = Assert.Throws<SafeException>(act);
			Assert.Equal("An invalid schedule detected!", exception.Message);
		}
	}
}
