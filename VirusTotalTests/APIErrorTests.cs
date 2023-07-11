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
            ResponseParser.VTReport vtScanReport = await vt.GetReportAsync("HitMe");

            // Assert
            Assert.NotNull(vtScanReport.Error);
  
        }
    }
}