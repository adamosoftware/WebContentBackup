using System.Windows.Forms;
using WebContentBackup.WinForm.Models;
using WinForms.Library;

namespace WebContentBackup.WinForm
{
	public partial class frmMain : Form
	{
		private JsonSDI<AppSettings> _sdi = null;

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			_sdi = new JsonSDI<AppSettings>("json", "*.json", "form closing");			
			_sdi.Controls.Add(tbUrl, m => m.Url);
			_sdi.Controls.Add(bldLocalPath, m => m.LocalPath);
			//_sdi.OpenAsync()
		}
	}
}