using JsonSettings;
using System.Security.Cryptography;

namespace LocalBlobBackup.Models
{
	public class AppSettings : JsonSettingsBase
	{
		[JsonProtect(DataProtectionScope.CurrentUser)]
		public string AccountName { get; set; }

		[JsonProtect(DataProtectionScope.CurrentUser)]
		public string AccountKey { get; set; }

		public string LocalPath { get; set; }		

		public override Scope Scope => Scope.User;
		public override string CompanyName => "Adam O'Neil";
		public override string ProductName => "Local Blob Backup";
		public override string Filename => "settings.json";
	}
}