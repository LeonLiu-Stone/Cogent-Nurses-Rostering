# pragma warning disable 1591

using System;
using System.IO;
using System.Globalization;
using CsvHelper;

namespace Nurses.Rostering.IO
{
    public static class Factory
    {
        public static CsvReader CreateCsvReader(StreamReader streamReader)
        {
            return new CsvReader(streamReader, CultureInfo.InvariantCulture);
        }
    }
}