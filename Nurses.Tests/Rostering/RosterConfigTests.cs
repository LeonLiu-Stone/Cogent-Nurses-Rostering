using Xunit;
using Moq;
using Nurses.Rostering;

namespace Nurses.Tests.Rostering
{
    public class RosterConfigTests
    {
        [Fact]
        public void RosterConfig_NursesPerShift_SetGet()
        {
            var nursesPerShift = 5;
            var config = new RosterConfig() { NursesPerShift = nursesPerShift };
            Assert.Equal(config.NursesPerShift, nursesPerShift);
        }

        [Fact]
        public void RosterConfig_ShiftNames_SetGet()
        {
            var shiftNames = new string[] { "shift1", "shift2" };
            var config = new RosterConfig() { ShiftNames = shiftNames };
            Assert.Equal(config.ShiftNames, shiftNames);
        }
    }
}