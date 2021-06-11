using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using Nurses.Rostering;

namespace Nurses.Tests.Rostering
{
    public class RosterBuilderTests
    {
        [Fact]
        public void RosterBuilder_Constructor_GivenNoArgs_UsesDefaultConfig()
        {
            var rb = new RosterBuilder();
            Assert.Equal(RosterBuilder.DefaultNursesPerShift, rb.config.NursesPerShift);
            Assert.Equal(RosterBuilder.DefaultShiftNames, rb.config.ShiftNames);
        }

        [Fact]
        public void RosterBuilder_Constructor_GivenArgs_OverridesDefaultConfig()
        {
            var config = new RosterConfig {
                NursesPerShift = 18,
                ShiftNames = new string[2] {"day", "night"}
            };
            var rb = new RosterBuilder(config);
            Assert.Equal(config, rb.config);
        }

        [Fact]
        public void RosterBuild_Build_ReturnsRoster()
        {
            var start = DateTime.Now; 
            var end = DateTime.Now;
            var nurses = new List<Nurse> {};
            Assert.IsType<Roster>(new RosterBuilder().Build(start, end, nurses));
        }
    }
}