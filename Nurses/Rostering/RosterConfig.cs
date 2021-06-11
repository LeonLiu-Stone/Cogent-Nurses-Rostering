# pragma warning disable 1591

using System.Collections.Generic;

namespace Nurses.Rostering
{
    public class RosterConfig
    {
        public int NursesPerShift { get; set; } 
        public string[] ShiftNames { get; set; }
    }
}