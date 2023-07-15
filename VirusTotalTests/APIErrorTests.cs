using System.Threading;
using VirusTotal;

namespace VirusTotalTests
{
    public class APIErrorTests
    {
        [Fact]
        public async  Task VT_InvalidAPIKey()
        {
            // Arrange
            VT vt = new("ThisKeyIsNotValid");

            // Act
            ResponseParser vtScanReport = await vt.GetReportAsync("ThisReportDoesNotExist");

            // Assert
            Assert.NotNull(vtScanReport.ErrorCode);
  
        }
    }
}