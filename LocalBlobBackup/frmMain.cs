using JsonSettings;
using LocalBlobBackup.Models;
using LocalBlobBackup.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using WinForms.Library;

namespace LocalBlobBackup
{
	public partial class frmMain : Form
	{
		private AppSettings _settings;

		public string[] StartupArguments { get; set; }

		public frmMain()
		{
			InitializeComponent();
		}

		private async void frmMain_Load(object sender, EventArgs e)
		{
			_settings = JsonSettingsBase.Load<AppSettings>();

			var binder = new ControlBinder<AppSettings>();
			binder.Document = _settings;
			binder.Add(tbAccountName, m => m.AccountName);
			binder.Add(tbAccountKey, m => m.AccountKey);
			binder.Add(bldLocalPath, m => m.LocalPath);
			binder.LoadValues();

			if (StartAutomatically())
			{
				await RunBackupInnerAsync();
				this.Close();
				Application.Exit();
			}
		}

		private bool StartAutomatically()
		{
			return (StartupArguments?.Any(s => s.Equals("/run")) ?? false);
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			_settings.Save();
		}

		private void bldLocalPath_BuilderClicked(object sender, WinForms.Library.Controls.BuilderEventArgs e)
		{
			bldLocalPath.SelectFolder(e);
		}

		private async void btnStartBackup_Click(object sender, EventArgs e)
		{
			try
			{
				await RunBackupInnerAsync();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private async System.Threading.Tasks.Task RunBackupInnerAsync()
		{
			BlobBackup backup = new BlobBackup();
			var reportProgress = new Progress<BlobBackup.Progress>(ReportProgress);
			await backup.ExecuteAsync(tbAccountName.Text, tbAccountKey.Text, bldLocalPath.Text, reportProgress);
		}

		private void ReportProgress(BlobBackup.Progress obj)
		{
			tslStatus.Text = obj.Message;
			toolStripProgressBar1.Visible = (obj.PercentDone > 0);
			toolStripProgressBar1.Value = obj.PercentDone;
		}
	}
}