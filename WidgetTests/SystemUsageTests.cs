using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget;

namespace WidgetTests
{
    public class SystemUsageTests
    {
        [Fact]
        public void GetMemoryUsage_DoesNotReturnNull()
        {
            // Arrange
            float ramUsage;

            // Act
            ramUsage = WindowsAPI.GetMemoryUsage();

            // Assert
            Assert.NotEqual(0f, ramUsage);
        }
        [Fact]
        public void GetMemoryUsage_DoesNotExceed100Percent()
        {
            // Arrange
            float memoryUsage;

            // Act
            memoryUsage = WindowsAPI.GetMemoryUsage();

            // Assert
            Assert.InRange(memoryUsage, 0f, 100f);
        }
        [Fact]
        public void GetCpuUsage_DoesNotReturnNull()
        {
            // Arrange
            float cpuUsage;

            // Act
            cpuUsage = WindowsAPI.GetCpuUsage();

            // Assert
            Assert.NotEqual(0f, cpuUsage);

        }
        [Fact]
        public void GetCpuUsage_DoesNotExceed100Percent()
        {
            // Arrange
            float cpuUsage;

            // Act
            cpuUsage = WindowsAPI.GetCpuUsage();

            // Assert
            Assert.InRange(cpuUsage, 0f, 100f);
        }
    }
}
