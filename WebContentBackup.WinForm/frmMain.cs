using JsonSettings;
using System.Windows.Forms;
using WebContentBackup.WinForm.Models;
using WinForms.Library;

namespace WebContentBackup.WinForm
{
	public partial class frmMain : Form
	{
		private AppSettings _settings = null;
		private ControlBinder<AppSettings> _binder = new ControlBinder<AppSettings>();

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			_settings = JsonSettingsBase.Load<AppSettings>();
			_binder.Document = _settings;
			_binder.Add(tbUrl, m => m.Url);
			_binder.Add(bldLocalPath, m => m.LocalPath);
			_binder.LoadValues();

		}

		private void bldLocalPath_BuilderClicked(object sender, WinForms.Library.Controls.BuilderEventArgs e)
		{
			bldLocalPath.SelectFolder(e);
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			_settings.Save();
		}
	}
}