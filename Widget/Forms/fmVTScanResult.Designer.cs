namespace Widget
{
    partial class fmVTScanResult
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
            Forms.Pigment pigment1 = new Forms.Pigment();
            Forms.Pigment pigment2 = new Forms.Pigment();
            Forms.Pigment pigment3 = new Forms.Pigment();
            Forms.Pigment pigment4 = new Forms.Pigment();
            Forms.Pigment pigment5 = new Forms.Pigment();
            Forms.Pigment pigment6 = new Forms.Pigment();
            Forms.Pigment pigment7 = new Forms.Pigment();
            dgvResult = new DataGridView();
            colAV = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colEngineName = new DataGridViewTextBoxColumn();
            colEngineVersion = new DataGridViewTextBoxColumn();
            colResult = new DataGridViewTextBoxColumn();
            colMethod = new DataGridViewTextBoxColumn();
            colEngineUpdate = new DataGridViewTextBoxColumn();
            eTheme1 = new Forms.eTheme();
            btnClose = new Forms.FButton();
            ((System.ComponentModel.ISupportInitialize)dgvResult).BeginInit();
            eTheme1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvResult
            // 
            dgvResult.AllowUserToAddRows = false;
            dgvResult.AllowUserToDeleteRows = false;
            dgvResult.AllowUserToOrderColumns = true;
            dgvResult.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResult.Columns.AddRange(new DataGridViewColumn[] { colAV, colCategory, colEngineName, colEngineVersion, colResult, colMethod, colEngineUpdate });
            dgvResult.Location = new Point(3, 32);
            dgvResult.Name = "dgvResult";
            dgvResult.ReadOnly = true;
            dgvResult.RowHeadersWidth = 51;
            dgvResult.RowTemplate.Height = 25;
            dgvResult.Size = new Size(770, 492);
            dgvResult.TabIndex = 0;
            // 
            // colAV
            // 
            colAV.HeaderText = "AV";
            colAV.Name = "colAV";
            colAV.ReadOnly = true;
            // 
            // colCategory
            // 
            colCategory.HeaderText = "Category";
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            // 
            // colEngineName
            // 
            colEngineName.HeaderText = "Engine";
            colEngineName.Name = "colEngineName";
            colEngineName.ReadOnly = true;
            // 
            // colEngineVersion
            // 
            colEngineVersion.HeaderText = "Version";
            colEngineVersion.Name = "colEngineVersion";
            colEngineVersion.ReadOnly = true;
            // 
            // colResult
            // 
            colResult.HeaderText = "Result";
            colResult.Name = "colResult";
            colResult.ReadOnly = true;
            // 
            // colMethod
            // 
            colMethod.HeaderText = "Method";
            colMethod.Name = "colMethod";
            colMethod.ReadOnly = true;
            // 
            // colEngineUpdate
            // 
            colEngineUpdate.HeaderText = "Updated";
            colEngineUpdate.Name = "colEngineUpdate";
            colEngineUpdate.ReadOnly = true;
            // 
            // eTheme1
            // 
            eTheme1.BackColor = Color.FromArgb(53, 53, 53);
            eTheme1.Controls.Add(btnClose);
            eTheme1.Controls.Add(dgvResult);
            eTheme1.Dock = DockStyle.Fill;
            eTheme1.Image = null;
            eTheme1.Location = new Point(0, 0);
            eTheme1.MoveHeight = 30;
            eTheme1.Name = "eTheme1";
            eTheme1.Resizable = true;
            eTheme1.Size = new Size(776, 566);
            eTheme1.TabIndex = 2;
            eTheme1.Text = "Scan result:";
            eTheme1.TransparencyKey = Color.Empty;
            // 
            // btnClose
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
            btnClose.Colors = new Forms.Pigment[] { pigment1, pigment2, pigment3, pigment4, pigment5, pigment6, pigment7 };
            btnClose.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(651, 530);
            btnClose.Name = "btnClose";
            btnClose.Shadow = true;
            btnClose.Size = new Size(122, 28);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.Click += btnClose_Click;
            // 
            // fmVTScanResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 566);
            Controls.Add(eTheme1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fmVTScanResult";
            Text = "fmVTScanResult";
            Load += fmVTScanResult_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResult).EndInit();
            eTheme1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvResult;
        private Forms.eTheme eTheme1;
        private DataGridViewTextBoxColumn colAV;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colEngineName;
        private DataGridViewTextBoxColumn colEngineVersion;
        private DataGridViewTextBoxColumn colResult;
        private DataGridViewTextBoxColumn colMethod;
        private DataGridViewTextBoxColumn colEngineUpdate;
        private Forms.FButton btnClose;
    }
}