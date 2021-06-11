using System;
using System.Collections.Generic;
using Nurses.Rostering.Models;
using Xunit;

namespace Nurses.Rostering.Test.FiveNursesNeedPerShiftPolicyTest
{
	public class Pass
	{
		[Fact]
		public void ReturnFalse_WhenNurseListIsNull()
		{
			//Arrange
			var shift = new Shift("Morning");
			List<Nurse> nurses = null;

			var stubILogger = StubHelper.StubILogger<FiveNursesNeedPerShiftPolicy>();

			var testedService = new FiveNursesNeedPerShiftPolicy(
				stubILogger.Object);

			//Act
			var result = testedService.Pass(shift, nurses);

			//Assert
			Assert.False(result);
		}

		[Fact]
		public void ThrowException_WhenShiftIsNull()
		{
			//Arrange
			Shift shift = null;
			var nurses = new List<Nurse>() {
				new Nurse("111111", "Lei"),
				new Nurse("222222", "Liu"),
			};

			var stubILogger = StubHelper.StubILogger<FiveNursesNeedPerShiftPolicy>();

			var testedService = new FiveNursesNeedPerShiftPolicy(
				stubILogger.Object);

			//Act
			Action act = () => testedService.Pass(shift, nurses);

			//Assert
			SafeException exception = Assert.Throws<SafeException>(act);
			Assert.Equal("An invalid shift detected!", exception.Message);
		}

		[Fact]
		public void ReturnFalse_WhenLessThanFiveNursesOnShift()
		{
			//Arrange
			var shift = new Shift("Morning");
			var nurses = new List<Nurse>() {
				new Nurse("111111", "Lei"),
				new Nurse("222222", "Liu"),
			};

			var stubILogger = StubHelper.StubILogger<FiveNursesNeedPerShiftPolicy>();

			var testedService = new FiveNursesNeedPerShiftPolicy(
				stubILogger.Object);

			//Act
			var result = testedService.Pass(shift, nurses);

			//Assert
			Assert.False(result);
		}


		[Fact]
		public void ReturnTrue_WhenMoreThanFiveNursesOnShift()
		{
			//Arrange
			var shift = new Shift("Morning");
			var nurses = new List<Nurse>() {
				new Nurse("111111", "LeiA"),
				new Nurse("222222", "LeiB"),
				new Nurse("333333", "LeiC"),
				new Nurse("444444", "LeiD"),
				new Nurse("555555", "LeiE"),
			};

			var stubILogger = StubHelper.StubILogger<FiveNursesNeedPerShiftPolicy>();

			var testedService = new FiveNursesNeedPerShiftPolicy(
				stubILogger.Object);

			//Act
			var result = testedService.Pass(shift, nurses);

			//Assert
			Assert.True(result);
		}
	}
}
