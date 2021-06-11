using Xunit;
using Moq;
using System;
using Nurses;
using Nurses.Rostering.IO;

namespace Nurses.Tests
{
    public class ProgramTests
    {
        private static DateTime _start = DateTime.Now;
        private static DateTime _end = _start.AddDays(+1);
        private static string _testFile = "../../../SampleData/two_nurses.csv";
        private static NursesFile _inputFile = new NursesFile(_testFile);

        [Fact]
        public static void Program_Main_WhenAllParamsAreValid_ReturnSuccess()
        {
            var returnCode = Program.Main(_start, _end, _inputFile);
            Assert.Equal((int)Program.ExitCode.Success, returnCode);
        }

        [Fact]
        public static void Program_Main_WhenTheInputFileDoesNotExist_ReturnsFailure()
        {
            var inputFile = new NursesFile("not/found.csv");
            var returnCode = Program.Main(_start, _end, inputFile);
            Assert.Equal((int)Program.ExitCode.Failure, returnCode);
        }

        [Fact]
        public static void Program_Main_WhenGivenADirectory_ReturnsFailure()
        {
            var inputFile = new NursesFile("../../../SampleData");
            var returnCode = Program.Main(_start, _end, inputFile);
            Assert.Equal((int)Program.ExitCode.Failure, returnCode);
        }

        [Fact]
        public static void Program_Main_WhenStartDateAfterEndDate_ReturnsFailure()
        {
            var end = _start.AddDays(-1);
            var returnCode = Program.Main(_start, end, _inputFile);
            Assert.Equal((int)Program.ExitCode.Failure, returnCode);
        }
    }
}