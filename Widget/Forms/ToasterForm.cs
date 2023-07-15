using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Widget.Forms
{
#pragma warning disable IDE1006
    public partial class ToasterForm : Form
    {
        /// <summary>
        /// Gets or sets the title of the toaster form.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the message of the toaster form.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the display duration of the toaster form.
        /// </summary>
        public int? DisplayDuration { get; set; } = 5000;
        /// <summary>
        /// Gets or set if fade effect should be used
        /// </summary>
        public bool FadeEffect { get; set; }

        private readonly System.Windows.Forms.Timer displayTimer;

        /// <summary>
        /// Creates a new toaster form and displays it.
        /// </summary>
        /// <param name="title">The title for the toaster form.</param>
        /// <param name="message">The message for the toaster form.</param>
        /// <param name="displayDuration">The duration (in milliseconds) to display the toaster form.</param>
        /// <param name="fadeEffect">Define if fade effect should be used</param>
        /// <remarks>
        /// This constructor is used to create a toaster form with the specified title, message, and display duration.
        /// Once created, the toaster form will be displayed for the specified duration and then automatically closed.
        /// </remarks>
        public ToasterForm(string title, string message, int displayDuration, bool fadeEffect)
        {
            this.Title = title;
            this.Message = message;
            this.DisplayDuration = displayDuration;
            this.FadeEffect = fadeEffect;

            InitializeComponent();

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
            
            if(FadeEffect)
                FormUtils.FadeInForm(this);

            displayTimer.Interval = DisplayDuration.HasValue ? DisplayDuration.Value : 5000;
            displayTimer.Start();
        }

        private void DisplayTimer_Tick(object? sender, EventArgs e)
        {
            displayTimer.Stop();
            displayTimer.Tick -= DisplayTimer_Tick; // Unsubscribve to timer event
            displayTimer.Dispose();

            if(FadeEffect)
                Task.Run(() => FormUtils.FadeOutForm(this)).Wait();
            
            if(!IsDisposed) // Check if already disposed before closing
                Close();
        }

        private void btnDismiss_Click(object sender, EventArgs e) => Close();


    }
}
