namespace LocalBlobBackup
{
	partial class frmMain
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
			this.label1 = new System.Windows.Forms.Label();
			this.tbAccountName = new System.Windows.Forms.TextBox();
			this.tbAccountKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.bldLocalPath = new WinForms.Library.Controls.BuilderTextBox();
			this.btnStartBackup = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(19, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Account Name:";
			// 
			// tbAccountName
			// 
			this.tbAccountName.Location = new System.Drawing.Point(125, 15);
			this.tbAccountName.Name = "tbAccountName";
			this.tbAccountName.Size = new System.Drawing.Size(247, 21);
			this.tbAccountName.TabIndex = 1;
			// 
			// tbAccountKey
			// 
			this.tbAccountKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAccountKey.Location = new System.Drawing.Point(125, 45);
			this.tbAccountKey.Name = "tbAccountKey";
			this.tbAccountKey.Size = new System.Drawing.Size(560, 21);
			this.tbAccountKey.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(36, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Account Key:";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.tslStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 151);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip1.Size = new System.Drawing.Size(697, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(117, 16);
			this.toolStripProgressBar1.Visible = false;
			// 
			// tslStatus
			// 
			this.tslStatus.Name = "tslStatus";
			this.tslStatus.Size = new System.Drawing.Size(39, 17);
			this.tslStatus.Text = "Ready";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(30, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Backup Path:";
			// 
			// bldLocalPath
			// 
			this.bldLocalPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bldLocalPath.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bldLocalPath.Location = new System.Drawing.Point(125, 75);
			this.bldLocalPath.Name = "bldLocalPath";
			this.bldLocalPath.Size = new System.Drawing.Size(560, 26);
			this.bldLocalPath.Suggestions = null;
			this.bldLocalPath.TabIndex = 5;
			this.bldLocalPath.Value = "";
			this.bldLocalPath.BuilderClicked += new WinForms.Library.Controls.BuilderEventHandler(this.bldLocalPath_BuilderClicked);
			// 
			// btnStartBackup
			// 
			this.btnStartBackup.Location = new System.Drawing.Point(125, 107);
			this.btnStartBackup.Name = "btnStartBackup";
			this.btnStartBackup.Size = new System.Drawing.Size(110, 23);
			this.btnStartBackup.TabIndex = 6;
			this.btnStartBackup.Text = "Start Backup";
			this.btnStartBackup.UseVisualStyleBackColor = true;
			this.btnStartBackup.Click += new System.EventHandler(this.btnStartBackup_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(697, 173);
			this.Controls.Add(this.btnStartBackup);
			this.Controls.Add(this.bldLocalPath);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbAccountKey);
			this.Controls.Add(this.tbAccountName);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Local Blob Backup";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbAccountName;
		private System.Windows.Forms.TextBox tbAccountKey;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel tslStatus;
		private System.Windows.Forms.Label label3;
		private WinForms.Library.Controls.BuilderTextBox bldLocalPath;
		private System.Windows.Forms.Button btnStartBackup;
	}
}

