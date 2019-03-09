using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBlobBackup.Extensions
{
	public static class BlobExtensions
	{
		public static async Task<IEnumerable<string>> ListContainersAsync(this CloudBlobClient client, string prefix = null)
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

		public static async Task<IEnumerable<CloudBlockBlob>> ListBlobsAsync(this CloudBlobClient client, string containerName, string prefix = null, IProgress<string> progress = null)
		{
			var container = client.GetContainerReference(containerName);

			BlobContinuationToken token = null;
			List<CloudBlockBlob> results = new List<CloudBlockBlob>();
			do
			{
				var response = await container.ListBlobsSegmentedAsync(prefix, token);
				token = response.ContinuationToken;

				var folders = response.Results.OfType<CloudBlobDirectory>();
				foreach (var folder in folders)
				{
					progress?.Report(folder.Prefix);
					var blobs = await ListBlobsAsync(client, containerName, folder.Prefix, progress);
					results.AddRange(blobs);
				}

				results.AddRange(response.Results.OfType<CloudBlockBlob>());
			} while (token != null);

			return results;
		}

		public static async Task<IEnumerable<BlobFolderInfo>> ListContainerFoldersAsync(this CloudBlobClient client, string containerName, string prefix = null, IProgress<string> progress = null, int rollupToDepth = 0)
		{
			var blobs = await ListBlobsAsync(client, containerName, prefix, progress);

			var results = blobs
				.GroupBy(item => Path.GetDirectoryName(item.Name))
				.Select(grp => new BlobFolderInfo() { Path = grp.Key, BlobCount = grp.Count() });

			if (rollupToDepth == 0)
			{
				// give me all the individual folders
				return results;
			}
			else
			{
				// consolidate nested folders to the specified depth and sum the blob counts accordingly
				string PathToDepth(string path, int depth)
				{
					const string separator = "\\";
					var folderNames = path.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
					return string.Join(separator, folderNames.Take(depth));
				}
				
				return results
					.GroupBy(item => PathToDepth(item.Path, rollupToDepth))
					.Select(grp => new BlobFolderInfo() { Path = grp.Key, BlobCount = grp.Sum(b => b.BlobCount) });
			}
		}
	}

	public class BlobFolderInfo
	{
		public string Path { get; set; }
		public int BlobCount { get; set; }
	}
}
