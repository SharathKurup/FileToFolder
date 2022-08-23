
namespace FileToFolder
{
    partial class FrmMain
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.btnSrc = new System.Windows.Forms.Button();
            this.btnDest = new System.Windows.Forms.Button();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.prgMoveStatus = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(661, 162);
            this.pnlMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.cboYear, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSrc, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSrc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDest, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDest, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnMove, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.prgMoveStatus, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 162);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // cboYear
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboYear, 2);
            this.cboYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(3, 3);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(655, 33);
            this.cboYear.TabIndex = 6;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.CboYear_SelectedIndexChanged);
            // 
            // txtSrc
            // 
            this.txtSrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSrc.Location = new System.Drawing.Point(3, 42);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.ReadOnly = true;
            this.txtSrc.Size = new System.Drawing.Size(489, 30);
            this.txtSrc.TabIndex = 7;
            // 
            // btnSrc
            // 
            this.btnSrc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSrc.Location = new System.Drawing.Point(498, 42);
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(160, 30);
            this.btnSrc.TabIndex = 8;
            this.btnSrc.Text = "Select Source";
            this.btnSrc.UseVisualStyleBackColor = true;
            this.btnSrc.Click += new System.EventHandler(this.BtnSrc_Click);
            // 
            // btnDest
            // 
            this.btnDest.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDest.Location = new System.Drawing.Point(498, 78);
            this.btnDest.Name = "btnDest";
            this.btnDest.Size = new System.Drawing.Size(160, 30);
            this.btnDest.TabIndex = 9;
            this.btnDest.Text = "Select Destination";
            this.btnDest.UseVisualStyleBackColor = true;
            this.btnDest.Click += new System.EventHandler(this.BtnDest_Click);
            // 
            // txtDest
            // 
            this.txtDest.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDest.Location = new System.Drawing.Point(3, 78);
            this.txtDest.Name = "txtDest";
            this.txtDest.ReadOnly = true;
            this.txtDest.Size = new System.Drawing.Size(489, 30);
            this.txtDest.TabIndex = 10;
            // 
            // btnMove
            // 
            this.btnMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMove.Location = new System.Drawing.Point(498, 114);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(160, 46);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "&Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.BtnMove_Click);
            // 
            // prgMoveStatus
            // 
            this.prgMoveStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgMoveStatus.Location = new System.Drawing.Point(3, 114);
            this.prgMoveStatus.Name = "prgMoveStatus";
            this.prgMoveStatus.Size = new System.Drawing.Size(489, 46);
            this.prgMoveStatus.TabIndex = 11;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 162);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move File To Folder";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.Button btnSrc;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnDest;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.ProgressBar prgMoveStatus;
    }
}

