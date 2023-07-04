using System.Text;
using Widget;

namespace WidgetTests
{
    public class DataProtectorTests
    {
        [Fact]
        public void ProtectData_ReturnsNonEmptyByteArray()
        {
            // Arrange
            byte[] data = new byte[] { 0x01, 0x02, 0x03 };

            // Act
            byte[] encryptedData = DataProtector.ProtectData(data);

            // Assert
            Assert.NotNull(encryptedData);
            Assert.True(encryptedData.Length > 0);
        }

        [Fact]
        public void UnprotectData_ReturnsNonEmptyByteArray()
        {
            // Arrange
            byte[] data = new byte[] { 0x01, 0x02, 0x03 };

            // Act
            byte[] encryptedData = DataProtector.ProtectData(data);
            byte[] decryptData = DataProtector.UnprotectData(encryptedData);

            // Assert
            Assert.NotNull(decryptData);
            Assert.True(encryptedData.Length > 0);
        }

        [Fact]
        public void ProtectData_EncryptsAndDecryptsData()
        {
            // Arrange
            string originalData = "VT-Desktop-Widget";
            byte[] originalBytes = Encoding.UTF8.GetBytes(originalData);

            // Act
            byte[] encryptedData = DataProtector.ProtectData(originalBytes);
            byte[] decryptedData = DataProtector.UnprotectData(encryptedData);
            string decryptedString = Encoding.UTF8.GetString(decryptedData);

            // Assert
            Assert.Equal(originalData, decryptedString);
        }

    }

}
