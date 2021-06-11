using Xunit;
using Moq;
using System.IO;
using Nurses.Rostering.IO;

namespace Nurses.Tests.Rostering.IO
{
    public class NursesFileTests
    {
        [Fact]
        public void NursesFile_FullName_Get_ReturnsFileFullName()
        {
            var fileName = "some/file.txt";
            var nursesFile = new NursesFile(fileName);

            Assert.Equal(
                Path.Join(Directory.GetCurrentDirectory(), fileName),
                nursesFile.FullName
            );
        }

        [Fact]
        public void NursesFile_OpenText_WithFileThatDoesExist_ReturnsStreamReader()
        {
            var fileName = "../../../SampleData/two_nurses.csv";
            Assert.IsType<StreamReader>(new NursesFile(fileName).OpenText());
        }

        [Fact]
        public void NursesFile_OpenText_WithDirectoryThatDoesNotExist_ThrowsError()
        {
            var fileName = "does/not/exist.csv";
            var nursesFile = new NursesFile(fileName);

            Assert.Throws<DirectoryNotFoundException>(() =>
                nursesFile.OpenText());
        }

        [Fact]
        public void NursesFile_OpenText_WithFileThatDoesNotExist_ThrowsError()
        {
            var fileName = "does.not.exist";
            var nursesFile = new NursesFile(fileName);

            Assert.Throws<FileNotFoundException>(() =>
                nursesFile.OpenText());
        }
    }
}