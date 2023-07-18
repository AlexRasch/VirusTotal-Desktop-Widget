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
        public void ParseStats_ValidJson()
        {
            // Arrange
            ResponseParser parser = new();
            string VirusTotalJsonResponse = @"
            {
                ""data"": {
                    ""attributes"": {
                        ""stats"": {
                            ""harmless"": 1,
                            ""type-unsupported"": 2,
                            ""suspicious"": 3,
                            ""confirmed-timeout"": 4,
                            ""timeout"": 5,
                            ""failure"": 6,
                            ""malicious"": 7,
                            ""undetected"": 0
                        }
                    }
                }
            }";
            // Act
            parser = parser.ParseReport(VirusTotalJsonResponse);

            // Assert
            Assert.Equal(1, parser.Stats.Harmless);
            Assert.Equal(2, parser.Stats.TypeUnsupported);
            Assert.Equal(3, parser.Stats.Suspicious);
            Assert.Equal(4, parser.Stats.ConfirmedTimeout);
            Assert.Equal(5, parser.Stats.Timeout);
            Assert.Equal(6, parser.Stats.Failure);
            Assert.Equal(7, parser.Stats.Malicious);
            Assert.Equal(0, parser.Stats.Undetected);
        }

        [Fact]
        public void ParseResults_ValidJson()
        {
            // Arrange
            ResponseParser parser = new();
            string VirusTotalJsonResponse = @"
            {
                ""data"": {
                    ""attributes"": {
                        ""results"": {
                            ""Bkav"": {
                                ""category"": ""undetected"",
                                ""engine_name"": ""Bkav"",
                                ""engine_version"": ""2.0.0.1"",
                                ""result"": null,
                                ""method"": ""blacklist"",
                                ""engine_update"": ""20230717""
                            },
                            ""AVG"": {
                                ""category"": ""malicious"",
                                ""engine_name"": ""AVG"",
                                ""engine_version"": ""22.11.7701.0"",
                                ""result"": ""EICAR Test-NOT virus!!!"",
                                ""method"": ""blacklist"",
                                ""engine_update"": ""20230718""
                            }
                        }
                    }
                }
            }";
            // Act
            parser = parser.ParseReport(VirusTotalJsonResponse);

            // Assert
            Assert.Equal("undetected", parser.Results["Bkav"].Category);
            Assert.Equal("Bkav", parser.Results["Bkav"].EngineName);
            Assert.Equal("2.0.0.1", parser.Results["Bkav"].EngineVersion);
            Assert.Null(parser.Results["Bkav"].Result);
            Assert.Equal("blacklist", parser.Results["Bkav"].Method);
            Assert.Equal("20230717", parser.Results["Bkav"].EngineUpdate);

            Assert.Equal("EICAR Test-NOT virus!!!", parser.Results["AVG"].Result);

        }

        [Fact]
        public void ParseType_ValidJson()
        {
            // Arrange
            ResponseParser parser = new();
            string VirusTotalJsonResponse = @"
                {
                   ""data"": {
                    ""type"": ""analysis""
                    }
                }
            ";

            // Act
            parser = parser.ParseReport(VirusTotalJsonResponse);

            // Assert
            Assert.Equal("analysis", parser.Type);
        }

        [Fact]
        public void ParseId_ValidJson()
        {
            // Arrange
            ResponseParser parser = new();
            string VirusTotalJsonResponse = @"
                {
                   ""data"": {
                    ""id"": ""OTdjMzlmNzk2NzhmMTc1NGRmMWRkZWVjYjhiYmM1MmQ6MTY4OTY0MzM4MA==""
                    }
                }
            ";

            // Act
            parser = parser.ParseReport(VirusTotalJsonResponse);

            // Assert
            Assert.Equal("OTdjMzlmNzk2NzhmMTc1NGRmMWRkZWVjYjhiYmM1MmQ6MTY4OTY0MzM4MA==", parser.Id);
        }

        [Fact]
        public void ParseLinks_ValidJson()
        {
            // Arrange
            ResponseParser parser = new();
            string VirusTotalJsonResponse = @"
                {
                   ""data"": {
                           ""links"": {
                            ""item"": ""https://www.virustotal.com/api/v3/files/b5ee37e8e6cfe7ad9e4fda2cc71209556eb7681c08d4e2079d97637668257263"",
                            ""self"": ""https://www.virustotal.com/api/v3/analyses/OTdjMzlmNzk2NzhmMTc1NGRmMWRkZWVjYjhiYmM1MmQ6MTY4OTY0MzM4MA==""
                            }
                    }
                }
            ";

            // Act
            parser = parser.ParseReport(VirusTotalJsonResponse);

            // Assert
            Assert.Equal("https://www.virustotal.com/api/v3/files/b5ee37e8e6cfe7ad9e4fda2cc71209556eb7681c08d4e2079d97637668257263", parser.Links.Item);
            Assert.Equal("https://www.virustotal.com/api/v3/analyses/OTdjMzlmNzk2NzhmMTc1NGRmMWRkZWVjYjhiYmM1MmQ6MTY4OTY0MzM4MA==", parser.Links.Self);
        }

    }
}
