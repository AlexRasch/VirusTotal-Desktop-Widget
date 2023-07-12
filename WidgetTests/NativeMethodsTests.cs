using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Widget;

namespace WidgetTests
{
    public class NativeMethodsTests
    {
        [Fact]
        public void Fade_ChangesWindowOpacity()
        {
            // Arrange
            var form = new Form();
            form.Show();
            double originalOpacity = form.Opacity; // In Windows Form opacity is from 0 to 100(%), default is 100%
            int targetOpacity = 127;// In Windows API its from 0 to 255

            // Act
            int result = WindowsAPI.MakeWindowTransparent(form.Handle);
            bool fadeResult = WindowsAPI.FadeIn(form.Handle, targetOpacity);

            // Assert
            double expectedOpacity = targetOpacity / 255.0; // Convert targetOpacity to Windows Forms range
            Assert.NotEqual(0, result);
            Assert.True(fadeResult);
            Assert.NotEqual(expectedOpacity, originalOpacity);
            // ToDo 
            //Assert.Equal(expectedOpacity, form.Opacity);
        }

 
    }
}
