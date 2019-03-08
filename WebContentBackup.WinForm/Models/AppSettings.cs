using JsonSettings;

namespace WebContentBackup.WinForm.Models
{
	public class AppSettings : JsonSettingsBase
	{
		public string Url { get; set; }
		public string LocalPath { get; set; }

		public override Scope Scope => Scope.User;
		public override string CompanyName => "Adam O'Neil";
		public override string ProductName => "Web Content Backup";
		public override string Filename => "settings.json";
	}
}