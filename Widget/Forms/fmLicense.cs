using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Widget
{
    public partial class fmLicense : Form
    {
        public fmLicense()
        {
            InitializeComponent();
        }

        private void fmLicense_Load(object sender, EventArgs e)
        {
            txtLicense.Text = License.LicenseText;
        }
    }
}
