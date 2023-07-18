using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusTotal;

namespace VirusTotalTests
{
    public class ParserTests
    {

        [Fact]
        public void ParseMetaFileInfo_ValidJson_HashesParsedCorrectly()
        {
            // Arrange
            ResponseParser parser = new();
            string VirusTotalJsonResponse = @"
            {
                ""meta"": {
                    ""file_info"": {
                        ""sha256"": ""b5ee37e8e6cfe7ad9e4fda2cc71209556eb7681c08d4e2079d97637668257263"",
                        ""sha1"": ""73126ab931bc9c134cdab8e058e20b89b6c2774d"",
                        ""md5"": ""97c39f79678f1754df1ddeecb8bbc52d"",
                        ""size"": 388862
                    }
                }
            }
            ";
            // Act
            parser = parser.ParseReport(VirusTotalJsonResponse);

            // Assert
            Assert.Equal("b5ee37e8e6cfe7ad9e4fda2cc71209556eb7681c08d4e2079d97637668257263", parser.FileInfo.SHA256);
            Assert.Equal("73126ab931bc9c134cdab8e058e20b89b6c2774d", parser.FileInfo.SHA1);
            Assert.Equal("97c39f79678f1754df1ddeecb8bbc52d", parser.FileInfo.MD5);
            Assert.Equal(388862, parser.FileInfo.Size);
        }

        [Fact]
        public void ParseType_ValidJson()
        {
            // Arrange
            ResponseParser parser = new();
            string VirusTotalJsonResponse = "";
        }

    }
}
