# pragma warning disable 1591

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Nurses.Rostering.IO
{
    public class NursesFileReader
    {
        public static List<Models.Nurse> readCSV(INursesFile nursesFile)
        {
            using (var csv = Factory.CreateCsvReader(nursesFile.OpenText()))
            {
                csv.Configuration.ShouldSkipRecord = row => row.All(string.IsNullOrWhiteSpace);
                return csv.GetRecords<Nurse>()
                .Distinct()
                .Select(n => new Models.Nurse(n.uid,n.name)).ToList();
            }
        }
    }
}