﻿namespace Widget
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
            components = new System.ComponentModel.Container();
            Forms.Pigment pigment8 = new Forms.Pigment();
            Forms.Pigment pigment9 = new Forms.Pigment();
            Forms.Pigment pigment10 = new Forms.Pigment();
            Forms.Pigment pigment11 = new Forms.Pigment();
            Forms.Pigment pigment12 = new Forms.Pigment();
            Forms.Pigment pigment13 = new Forms.Pigment();
            Forms.Pigment pigment14 = new Forms.Pigment();
            dgvResult = new DataGridView();
            errorCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fileInfoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            resultsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            linksDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isCompleteDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            responseParserBindingSource = new BindingSource(components);
            eTheme1 = new Forms.eTheme();
            btnExport = new Forms.eButton();
            lblFileSize = new Label();
            btnClose = new Forms.FButton();
            ((System.ComponentModel.ISupportInitialize)dgvResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)responseParserBindingSource).BeginInit();
            eTheme1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvResult
            // 
            dgvResult.AllowUserToAddRows = false;
            dgvResult.AllowUserToDeleteRows = false;
            dgvResult.AllowUserToOrderColumns = true;
            dgvResult.AutoGenerateColumns = false;
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvResult.BorderStyle = BorderStyle.None;
            dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResult.Columns.AddRange(new DataGridViewColumn[] { errorCodeDataGridViewTextBoxColumn, fileInfoDataGridViewTextBoxColumn, dateDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, statsDataGridViewTextBoxColumn, resultsDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, idDataGridViewTextBoxColumn, linksDataGridViewTextBoxColumn, isCompleteDataGridViewCheckBoxColumn });
            dgvResult.DataSource = responseParserBindingSource;
            dgvResult.Location = new Point(2, 91);
            dgvResult.Name = "dgvResult";
            dgvResult.ReadOnly = true;
            dgvResult.RowHeadersVisible = false;
            dgvResult.RowHeadersWidth = 51;
            dgvResult.RowTemplate.Height = 25;
            dgvResult.Size = new Size(920, 450);
            dgvResult.TabIndex = 0;
            dgvResult.CellFormatting += dgvResult_CellFormatting;
            // 
            // errorCodeDataGridViewTextBoxColumn
            // 
            errorCodeDataGridViewTextBoxColumn.DataPropertyName = "ErrorCode";
            errorCodeDataGridViewTextBoxColumn.HeaderText = "ErrorCode";
            errorCodeDataGridViewTextBoxColumn.Name = "errorCodeDataGridViewTextBoxColumn";
            errorCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fileInfoDataGridViewTextBoxColumn
            // 
            fileInfoDataGridViewTextBoxColumn.DataPropertyName = "FileInfo";
            fileInfoDataGridViewTextBoxColumn.HeaderText = "FileInfo";
            fileInfoDataGridViewTextBoxColumn.Name = "fileInfoDataGridViewTextBoxColumn";
            fileInfoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            dateDataGridViewTextBoxColumn.HeaderText = "Date";
            dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statsDataGridViewTextBoxColumn
            // 
            statsDataGridViewTextBoxColumn.DataPropertyName = "Stats";
            statsDataGridViewTextBoxColumn.HeaderText = "Stats";
            statsDataGridViewTextBoxColumn.Name = "statsDataGridViewTextBoxColumn";
            statsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // resultsDataGridViewTextBoxColumn
            // 
            resultsDataGridViewTextBoxColumn.DataPropertyName = "Results";
            resultsDataGridViewTextBoxColumn.HeaderText = "Results";
            resultsDataGridViewTextBoxColumn.Name = "resultsDataGridViewTextBoxColumn";
            resultsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            typeDataGridViewTextBoxColumn.HeaderText = "Type";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // linksDataGridViewTextBoxColumn
            // 
            linksDataGridViewTextBoxColumn.DataPropertyName = "Links";
            linksDataGridViewTextBoxColumn.HeaderText = "Links";
            linksDataGridViewTextBoxColumn.Name = "linksDataGridViewTextBoxColumn";
            linksDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isCompleteDataGridViewCheckBoxColumn
            // 
            isCompleteDataGridViewCheckBoxColumn.DataPropertyName = "IsComplete";
            isCompleteDataGridViewCheckBoxColumn.HeaderText = "IsComplete";
            isCompleteDataGridViewCheckBoxColumn.Name = "isCompleteDataGridViewCheckBoxColumn";
            isCompleteDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // responseParserBindingSource
            // 
            responseParserBindingSource.DataSource = typeof(VirusTotal.ResponseParser);
            // 
            // eTheme1
            // 
            eTheme1.BackColor = Color.FromArgb(53, 53, 53);
            eTheme1.Controls.Add(btnExport);
            eTheme1.Controls.Add(dgvResult);
            eTheme1.Controls.Add(lblFileSize);
            eTheme1.Controls.Add(btnClose);
            eTheme1.Dock = DockStyle.Fill;
            eTheme1.Image = null;
            eTheme1.Location = new Point(0, 0);
            eTheme1.MoveHeight = 30;
            eTheme1.Name = "eTheme1";
            eTheme1.Resizable = true;
            eTheme1.Size = new Size(921, 600);
            eTheme1.TabIndex = 2;
            eTheme1.Text = "Scan result:";
            eTheme1.TransparencyKey = Color.Empty;
            // 
            // btnExport
            // 
            btnExport.Image = null;
            btnExport.Location = new Point(12, 43);
            btnExport.Name = "btnExport";
            btnExport.NoRounding = false;
            btnExport.Size = new Size(97, 32);
            btnExport.TabIndex = 4;
            btnExport.Text = "Export";
            btnExport.Click += btnExport_Click;
            // 
            // lblFileSize
            // 
            lblFileSize.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblFileSize.ForeColor = Color.WhiteSmoke;
            lblFileSize.Location = new Point(12, 560);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(383, 28);
            lblFileSize.TabIndex = 2;
            lblFileSize.Text = "File size:";
            // 
            // btnClose
            // 
            pigment8.Name = "Border";
            pigment8.Value = Color.FromArgb(254, 133, 0);
            pigment9.Name = "Backcolor";
            pigment9.Value = Color.FromArgb(25, 25, 25);
            pigment10.Name = "Highlight";
            pigment10.Value = Color.FromArgb(255, 197, 19);
            pigment11.Name = "Gradient1";
            pigment11.Value = Color.FromArgb(255, 175, 12);
            pigment12.Name = "Gradient2";
            pigment12.Value = Color.FromArgb(255, 127, 1);
            pigment13.Name = "Text Color";
            pigment13.Value = Color.White;
            pigment14.Name = "Text Shadow";
            pigment14.Value = Color.FromArgb(30, 0, 0, 0);
            btnClose.Colors = new Forms.Pigment[] { pigment8, pigment9, pigment10, pigment11, pigment12, pigment13, pigment14 };
            btnClose.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(787, 560);
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
            ClientSize = new Size(921, 600);
            Controls.Add(eTheme1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fmVTScanResult";
            ShowIcon = false;
            Text = "fmVTScanResult";
            Load += fmVTScanResult_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)responseParserBindingSource).EndInit();
            eTheme1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvResult;
        private Forms.eTheme eTheme1;
        private Forms.FButton btnClose;
        private Label lblFileSize;
        private BindingSource responseParserBindingSource;
        private Forms.eButton btnExport;
        private DataGridViewTextBoxColumn errorCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fileInfoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resultsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn linksDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isCompleteDataGridViewCheckBoxColumn;
    }
}