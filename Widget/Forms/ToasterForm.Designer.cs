namespace Widget.Forms
{
    partial class ToasterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Pigment pigment1 = new Pigment();
            Pigment pigment2 = new Pigment();
            Pigment pigment3 = new Pigment();
            Pigment pigment4 = new Pigment();
            Pigment pigment5 = new Pigment();
            Pigment pigment6 = new Pigment();
            Pigment pigment7 = new Pigment();
            eTheme1 = new eTheme();
            lblMessage = new Label();
            btnDismiss = new FButton();
            eTheme1.SuspendLayout();
            SuspendLayout();
            // 
            // eTheme1
            // 
            eTheme1.BackColor = Color.FromArgb(53, 53, 53);
            eTheme1.Controls.Add(lblMessage);
            eTheme1.Controls.Add(btnDismiss);
            eTheme1.Dock = DockStyle.Fill;
            eTheme1.Image = null;
            eTheme1.Location = new Point(0, 0);
            eTheme1.MoveHeight = 30;
            eTheme1.Name = "eTheme1";
            eTheme1.Resizable = true;
            eTheme1.Size = new Size(356, 113);
            eTheme1.TabIndex = 0;
            eTheme1.Text = "Message:";
            eTheme1.TransparencyKey = Color.Empty;
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Transparent;
            lblMessage.ForeColor = Color.WhiteSmoke;
            lblMessage.Location = new Point(12, 36);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(332, 34);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.\r\n";
            // 
            // btnDismiss
            // 
            pigment1.Name = "Border";
            pigment1.Value = Color.FromArgb(254, 133, 0);
            pigment2.Name = "Backcolor";
            pigment2.Value = Color.FromArgb(25, 25, 25);
            pigment3.Name = "Highlight";
            pigment3.Value = Color.FromArgb(255, 197, 19);
            pigment4.Name = "Gradient1";
            pigment4.Value = Color.FromArgb(255, 175, 12);
            pigment5.Name = "Gradient2";
            pigment5.Value = Color.FromArgb(255, 127, 1);
            pigment6.Name = "Text Color";
            pigment6.Value = Color.White;
            pigment7.Name = "Text Shadow";
            pigment7.Value = Color.FromArgb(30, 0, 0, 0);
            btnDismiss.Colors = new Pigment[] { pigment1, pigment2, pigment3, pigment4, pigment5, pigment6, pigment7 };
            btnDismiss.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnDismiss.Location = new Point(242, 75);
            btnDismiss.Name = "btnDismiss";
            btnDismiss.Shadow = true;
            btnDismiss.Size = new Size(102, 26);
            btnDismiss.TabIndex = 0;
            btnDismiss.Text = "Dismiss";
            btnDismiss.Click += btnDismiss_Click;
            // 
            // ToasterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 113);
            Controls.Add(eTheme1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ToasterForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Toaster";
            Load += ToasterForm_Load;
            eTheme1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private eTheme eTheme1;
        private FButton btnDismiss;
        private Label lblMessage;
    }
}