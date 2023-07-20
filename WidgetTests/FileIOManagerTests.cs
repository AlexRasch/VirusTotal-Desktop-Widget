using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusTotal;
using Widget;

namespace WidgetTests
{
    public class FileIOManagerTests
    {
        [Fact]
        public void SaveFile_CreatesFile()
        {
            // Arrange
            string APIResponseRaw = "Hello World";
            string FullFilePath = Path.Combine(Path.GetTempPath(), "CreateFileTest.txt");
            FileIOManager exporter = new (APIResponseRaw, FullFilePath);

            // Act
            bool SavedFile = exporter.WriteFile();
            bool FileExist = File.Exists(FullFilePath);

            // Assert
            Assert.True(SavedFile);
            Assert.True(FileExist);
            Assert.False(exporter.HasError);
            Assert.Equal(SavedFile, FileExist);
        }

        [Fact]
        public void ExporterPathToLong_ThrowsException()
        {
            // Arrange
            string APIResponseRaw = "Hello World";
            string PathToLong = new string('a', 600); // The maximum path length limit in Windows is 260 characters
            FileIOManager exporter = new(APIResponseRaw, PathToLong);

            // Act
            Exception exception = Record.Exception(() => exporter.WriteFile());
            
            // Assert
            Assert.NotNull(exception);
            Assert.True(exporter.HasError);
        }

        [Fact]
        public void ExporterDataIsEmpty_ThrowsException()
        {
            // Arrange
            string APIResponseRaw = "Hello World";
            string InvalidPath = new string('a', 16);
            FileIOManager exporter = new(APIResponseRaw, InvalidPath);

            // Act
            Exception exception = Record.Exception(() => exporter.WriteFile());

            // Assert
            Assert.NotNull(exception);
            Assert.True(exporter.HasError);
        }

    }
}
