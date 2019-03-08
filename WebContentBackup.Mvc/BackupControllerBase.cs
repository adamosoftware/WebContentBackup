using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebContentBackup.Models;

namespace WebContentBackup.Mvc
{
	public abstract class BackupControllerBase : Controller
	{
		/// <summary>
		/// Enumerates all resources on the server
		/// </summary>
		public abstract Task<IEnumerable<Resource>> GetAllResourcesAsync(DateTime? modifiedAfter);

		public async Task<JsonResult> Resources(DateTime? modifiedAfter)
		{
			var result = await GetAllResourcesAsync(modifiedAfter);
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}