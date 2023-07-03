namespace Widget
{
    partial class fmLicense
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
            btnAccept = new Button();
            txtLicense = new TextBox();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(490, 382);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(91, 31);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            // 
            // txtLicense
            // 
            txtLicense.Location = new Point(12, 12);
            txtLicense.Multiline = true;
            txtLicense.Name = "txtLicense";
            txtLicense.Size = new Size(569, 364);
            txtLicense.TabIndex = 1;
            // 
            // fmLicense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 425);
            Controls.Add(txtLicense);
            Controls.Add(btnAccept);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmLicense";
            Text = "fmLicense";
            Load += fmLicense_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAccept;
        private TextBox txtLicense;
    }
}