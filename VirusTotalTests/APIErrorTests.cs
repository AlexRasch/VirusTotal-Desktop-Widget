using System.Threading;
using VirusTotal;

namespace VirusTotalTests
{
    public class APIErrorTests
    {
        [Fact]
        public void InvalidApiKeyLength_ThrowsException()
        {
            // Arrange
            string InvalidApiKeyLength = new string('a', 32);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new VT(InvalidApiKeyLength));
        }

        [Fact]
        public void ValidApiKeyLength_NoExecption()
        {
            // Arrange
            string ValidApiKeyLength = new string('a', 64);

            // Act & Assert
            Assert.Null(Record.Exception(() => new VT(ValidApiKeyLength)));
        }

        [Fact]
        public async Task GetReportAsync_InvalidAPIKey_ReturnsErrorCode()
        {
            // Arrange
            string testAPIKey = new string('a', 64);
            VT vt = new(testAPIKey);

            // Act
            ResponseParser vtScanReport = await vt.GetReportAsync("ThisReportDoesNotExist");

            // Assert
            Assert.NotNull(vtScanReport.ErrorCode);
        }
    }
}