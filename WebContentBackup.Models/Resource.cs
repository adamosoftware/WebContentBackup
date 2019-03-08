using System;

namespace WebContentBackup.Models
{
	/// <summary>
	/// Any resource on my site that I want to make sure is backed up
	/// </summary>
	public class Resource
	{
		/// <summary>
		/// Resource URL
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Byte length of content
		/// </summary>
		public long Length { get; set; }

		/// <summary>
		/// Date created or modified (as defined by the server)
		/// </summary>
		public DateTime Timestamp { get; set; }
	}
}