using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebContentBackup.Models;

namespace WebContentBackup.Mvc
{
	public abstract class ServerBase
	{
		/// <summary>
		/// Enumerates all resources on the server
		/// </summary>
		public abstract Task<IEnumerable<Resource>> GetAllResourcesAsync(DateTime? modifiedAfter);
	}
}