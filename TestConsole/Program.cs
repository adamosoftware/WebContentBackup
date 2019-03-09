using DevSecrets.Library;
using LocalBlobBackup.Extensions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;

namespace TestConsole
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var secrets = DevSecretsDictionary.Load("WebContentBackup.sln");
			var account = new CloudStorageAccount(new StorageCredentials(secrets.Contents["accountName"], secrets.Contents["accountKey"]), true);
			var client = account.CreateCloudBlobClient();

			/*
			var containers = client.ListContainersAsync().Result;
			foreach (string container in containers)
			{
				Console.WriteLine(container);
			}
			*/

			Progress<string> progress = new Progress<string>(WriteFolder);
			var folders = client.ListContainerFoldersAsync("aerie-hpmachine", progress: progress).Result;
			foreach (var folder in folders)
			{
				Console.WriteLine($"{folder.Path}: {folder.BlobCount}");
			}
			Console.WriteLine("done");
			Console.ReadLine();
		}

		private static void WriteFolder(string obj)
		{
			Console.WriteLine(obj);
		}
	}
}