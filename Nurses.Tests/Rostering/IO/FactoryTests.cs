using Xunit;
using Moq;
using System.IO;
using System.Collections.Generic;
using Nurses.Rostering.IO;

namespace Nurses.Tests.Rostering.IO
{
    public class FactoryTests
    {
        [Fact]
        public void Factory_CreateCsvReader_ReturnsCsvReaderFromStream()
        {
            var csvLines = new List<string> { "line1", "line2" };
            var reader = TestHelpers.CreateStreamReader(csvLines);
            var csvReader = Factory.CreateCsvReader(reader);
            
            Assert.IsType<CsvHelper.CsvReader>(csvReader);
        }
    }
}