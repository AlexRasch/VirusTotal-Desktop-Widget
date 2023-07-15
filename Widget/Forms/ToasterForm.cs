using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Widget.Forms
{
    public partial class ToasterForm : Form
    {
        [Required(ErrorMessage = "Title is required.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Message is required.")]
        public string? Message { get; set; }
        public int? DisplayDuration { get; set; } = 5000;

        private System.Windows.Forms.Timer displayTimer;

        public ToasterForm(string title, string message, int displayDuration)
        {
            this.Title = title;
            this.Message = message;
            this.DisplayDuration = displayDuration;

            InitializeComponent();

            eTheme1.Text = Title ?? string.Empty;
            lblMessage.Text = Message ?? string.Empty;

            displayTimer = new System.Windows.Forms.Timer();
            displayTimer.Tick += DisplayTimer_Tick;

        }

        private void ToasterForm_Load(object sender, EventArgs e)
        {
            int distanceFromRightEdge = 10;
            int distanceFromBottomEdge = 80;
            int formX = Screen.PrimaryScreen.Bounds.Width - Width - distanceFromRightEdge;
            int formY = Screen.PrimaryScreen.Bounds.Height - (Height + distanceFromBottomEdge);
            Location = new System.Drawing.Point(formX, formY);

            this.MinimumSize = new Size(Width, Height);
            this.MaximumSize = this.MinimumSize;

            displayTimer.Interval = DisplayDuration.HasValue ? DisplayDuration.Value : 5000;
            displayTimer.Start();
        }

        private void DisplayTimer_Tick(object? sender, EventArgs e)
        {
            displayTimer.Stop();
            this.Close();
            Debug.WriteLine("HitMe");
        }

        private void btnDismiss_Click(object sender, EventArgs e) => this.Close();


    }
}
