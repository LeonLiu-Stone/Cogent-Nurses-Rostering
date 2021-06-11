using Xunit;
using Moq;
using System.Collections.Generic;
using Nurses.Rostering;
using Nurses.Rostering.IO;
using CsvHelper;

namespace Nurses.Tests.Rostering.IO
{
    public class NursesFileReaderTests
    {
        private static string _headerRow = "uid,name";
        private static string _nurse1Name = "Steve";
        private static string _nurse2Name = "Tony";
        private static string _nurse1Uid = "123abc";
        private static string _nurse2Uid = "456def";

        [Fact]
        public void NursesFileReader_ReadCsv_WhenRowsContainValidData_CreatesNursesFromCSVRows()
        {
            var csvLines = new List<string> {
                _headerRow,
                $"{_nurse1Name},{_nurse1Uid}",
                $"{_nurse2Name},{_nurse2Uid}"
            };

            var mockNursesFile = _createMockNursesFile(csvLines);          
            var nurses = NursesFileReader.readCSV(mockNursesFile);

            Assert.Equal(nurses, new List<Nurse> {
                new Nurse { uid = _nurse1Name, name = _nurse1Uid },
                new Nurse { uid = _nurse2Name, name = _nurse2Uid }
            });
        }

        [Fact]
        public void NursesFileReader_ReadCsv_WhenHeaderRowIncorrect_CreatesNursesFromCSVRows()
        {
            var csvLines = new List<string> {
                "name,id",
                $"{_nurse1Name},{_nurse1Uid}",
                $"{_nurse2Name},{_nurse2Uid}"
            };

            var mockNursesFile = _createMockNursesFile(csvLines);          

            Assert.Throws<HeaderValidationException>(() => 
                NursesFileReader.readCSV(mockNursesFile));
        }

        [Fact]
        public void NursesFileReader_ReadCsv_WhenHeaderRowIsMissing_ThrowsHeaderValidationException()
        { 
            var csvLines = new List<string> {
                $"{_nurse1Name},{_nurse1Uid}",
                $"{_nurse2Name},{_nurse2Uid}"
            };

            var mockNursesFile = _createMockNursesFile(csvLines);

            Assert.Throws<HeaderValidationException>(() => 
                NursesFileReader.readCSV(mockNursesFile));
        }
        
        [Fact]
        public void NursesFileReader_ReadCsv_WhenEmptyRowsArePresent_SkipsOverThem()
        {
            var csvLines = new List<string> {
                _headerRow,
                $"{_nurse1Name},{_nurse1Uid}",
                " ,   ",
                $"{_nurse2Name},{_nurse2Uid}",
                ","
            };

            var mockNursesFile = _createMockNursesFile(csvLines);          
            var nurses = NursesFileReader.readCSV(mockNursesFile);

            Assert.Equal(nurses, new List<Nurse> {
                new Nurse { uid = _nurse1Name, name = _nurse1Uid },
                new Nurse { uid = _nurse2Name, name = _nurse2Uid }
            });
        }

        [Fact]
        public void NursesFileReader_ReadCsv_WhenDuplicateRowsArePresent_SkipsOverThem()
        {   
            var csvLines = new List<string> {
                _headerRow,
                $"{_nurse1Name},{_nurse1Uid}",
                $"{_nurse2Name},{_nurse2Uid}",
                $"{_nurse1Name},{_nurse1Uid}"
            };

            var mockNursesFile = _createMockNursesFile(csvLines);          
            var nurses = NursesFileReader.readCSV(mockNursesFile);

            Assert.Equal(nurses, new List<Nurse> {
                new Nurse { uid = _nurse1Name, name = _nurse1Uid },
                new Nurse { uid = _nurse2Name, name = _nurse2Uid }
            });
        }

        private static INursesFile _createMockNursesFile(List<string> csvLines)
        {
            var reader = TestHelpers.CreateStreamReader(csvLines);
            var mockNursesFile = new Mock<INursesFile>();
            mockNursesFile.Setup(m => m.OpenText()).Returns(reader);
            return mockNursesFile.Object;
        }
    }
}
