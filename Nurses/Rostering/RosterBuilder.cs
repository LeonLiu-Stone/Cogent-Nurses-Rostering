# pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Collections;

namespace Nurses.Rostering
{
    public class RosterBuilder
    {
        public const int DefaultNursesPerShift = 5;
        public static readonly string[] DefaultShiftNames = {"morning", "evening", "night"};
        
        private static RosterConfig _config;

        public RosterBuilder() {
            _config = new RosterConfig() {
                NursesPerShift = DefaultNursesPerShift,
                ShiftNames = DefaultShiftNames
            };
        }

        public RosterBuilder(RosterConfig rosterConfig)
        {
            _config = rosterConfig;
        }

        public Roster Build(DateTime start, DateTime end, List<Nurse> nurses)
        {
            // TODO: Implement Rostering Logic
            return new Roster();
        }

        public RosterConfig config { get { return _config; } }
    }
}