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
			var containers = await ListContainersAsync(client);

			int containersDone = 0;
			int totalContainers = containers.Count();

			foreach (string containerName in containers)
			{
				containersDone++;
				progress.Report(new Progress(containersDone, totalContainers) { Message = $"Listing blobs in {containerName}..." });
				var blobs = await ListBlobsAsync(client, containerName);

				foreach (var blob in blobs)
				{
					
				}
			}
		}

		private async Task<IEnumerable<string>> ListContainersAsync(CloudBlobClient client, string prefix = null)
		{
			BlobContinuationToken token = null;
			List<string> results = new List<string>();
			do
			{
				var response = await client.ListContainersSegmentedAsync(prefix, token);
				token = response.ContinuationToken;
				results.AddRange(response.Results.Select(c => c.Name));
			}
			while (token != null);

			return results;
		}

		private async Task<IEnumerable<CloudBlockBlob>> ListBlobsAsync(CloudBlobClient client, string containerName, string prefix = null)
		{
			var container = client.GetContainerReference(containerName);

			BlobContinuationToken token = null;
			List<CloudBlockBlob> results = new List<CloudBlockBlob>();
			do
			{
				var response = await container.ListBlobsSegmentedAsync(prefix, token);
				token = response.ContinuationToken;
				results.AddRange(response.Results.OfType<CloudBlockBlob>());
			} while (token != null);

			return results;
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