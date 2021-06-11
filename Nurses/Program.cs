# pragma warning disable 1591

using System;
using Nurses.Rostering;
using Nurses.Rostering.IO;

namespace Nurses
{
    public class Program
    {
        /// <param name="start">The start date of the schedule</param>
        /// <param name="end">The end date of the schedule</param>
        /// <param name="inputFile">The input file to use for schedule generation</param>
        public static int Main(DateTime start, DateTime end, NursesFile inputFile)
        {
            try {
                _validateInputs(start, end);
                var nurses = NursesFileReader.readCSV(inputFile);
                Console.WriteLine($"\nfound data for {nurses.Count} nurses in {inputFile.FullName}");
                Console.WriteLine($"\ncalculating roster for {start.ToString("d")} until {end.ToString("d")}");
                var roster = new RosterBuilder().Build(start, end, nurses);
                roster.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError: {0}", ex.Message);
                return (int)ExitCode.Failure;
            }

            return (int)ExitCode.Success;
        }

        public enum ExitCode : int {
            Success = 0,
            Failure = 1,
        }

        private static void _validateInputs(DateTime start, DateTime end)
        {
            if(start >= end) {
                throw new ArgumentException("The start date must occur before the end date!");
            }
        }
    }
}
