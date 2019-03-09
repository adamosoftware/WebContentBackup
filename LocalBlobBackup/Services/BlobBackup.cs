using LocalBlobBackup.Extensions;
using LocalBlobBackup.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBlobBackup.Services
{
	public class BlobBackup
	{
		public async Task ExecuteAsync(string accountName, string accountKey, string localPath, IProgress<Progress> progress)
		{
			string backupPath = Path.Combine(localPath, accountName);
			if (!Directory.Exists(backupPath)) Directory.CreateDirectory(backupPath);

			var account = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
			var client = account.CreateCloudBlobClient();

			progress.Report(new Progress() { Message = "Listing containers..." });
			var containers = await client.ListContainersAsync();

			int containersDone = 0;
			int totalContainers = containers.Count();
			int totalDownloads = 0;
			int totalSkipped = 0;

			foreach (string containerName in containers)
			{
				containersDone++;
				progress.Report(new Progress(containersDone, totalContainers) { Message = $"Listing blobs in {containerName}..." });
				var blobs = await client.ListBlobsAsync(containerName);

				foreach (var blob in blobs)
				{
					progress.Report(new Progress(containersDone, totalContainers) { Message = $"Downloading {containerName}/{blob.Name}" });

					string localFile = Path.Combine(backupPath, containerName, blob.Name);
					string filePath = Path.GetDirectoryName(localFile);
					if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

					if (BackupBlob(blob, localFile, out bool localExists))
					{
						totalDownloads++;
						if (localExists) File.Delete(localFile);
						await blob.DownloadToFileAsync(localFile, FileMode.Create);
					}
					else
					{
						totalSkipped++;
					}
				}
			}

			progress.Report(new Progress() { Message = $"Finished {totalDownloads} files download, {totalSkipped} files skipped" });
		}

		private bool BackupBlob(CloudBlockBlob blob, string localFile, out bool localExists)
		{
			if (File.Exists(localFile))
			{
				localExists = true;
				FileInfo fi = new FileInfo(localFile);
				return (blob.Properties.LastModified.Value.UtcDateTime > fi.LastWriteTimeUtc);
			}
			else
			{
				localExists = false;
				return true;				
			}
		}

		public class Progress
		{
			public Progress()
			{
			}

			public Progress(int itemsDone, int totalItems)
			{
				PercentDone = Convert.ToInt32((Convert.ToSingle(itemsDone) / Convert.ToSingle(totalItems)) * 100);
			}

			public int PercentDone { get; set; }
			public string Message { get; set; }
		}
	}
}