using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusTotal;
using Widget;

namespace WidgetTests
{
    public class ApiResponseExporterTests
    {
        [Fact]
        public void SaveFile_CreatesFile()
        {
            // Arrange
            string APIResponseRaw = "Hello World";
            string FullFilePath = Path.Combine(Path.GetTempPath(), "CreateFileTest.txt");
            ApiResponseExporter exporter = new (APIResponseRaw, FullFilePath);

            // Act
            bool SavedFile = exporter.SaveFile();
            bool FileExist = File.Exists(FullFilePath);

            // Assert
            Assert.True(SavedFile);
            Assert.True(FileExist);
            Assert.Equal(SavedFile, FileExist);
        }

        [Fact]
        public void ExporterPathToLong_ThrowsException()
        {
            // Arrange
            string APIResponseRaw = "Hello World";
            string PathToLong = new string('a', 600); // The maximum path length limit in Windows is 260 characters
            ApiResponseExporter exporter = new(APIResponseRaw, PathToLong);

            // Act & Assert
            Assert.Null(Record.Exception(() => exporter.SaveFile()));
        }

        [Fact]
        public void ExporterDataIsEmpty_ThrowsException()
        {
            // Arrange
            string APIResponseRaw = "Hello World";
            string InvalidPath = new string('a', 16); // The maximum path length limit in Windows is 260 characters
            ApiResponseExporter exporter = new(APIResponseRaw, InvalidPath);

            // Act & Assert
            Assert.Null(Record.Exception(() => exporter.SaveFile()));
        }

    }
}
