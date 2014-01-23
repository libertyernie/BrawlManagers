using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace BrawlStageManager.RegistryUtilities {
	public class GeneralRegistry {
		public const string SUBKEY = "SOFTWARE\\libertyernie\\BrawlStageManager";

		public static void ClearAllStageManager() {
			var libertyernie = Registry.CurrentUser.CreateSubKey("SOFTWARE\\libertyernie");
			libertyernie.DeleteSubKey("BrawlStageManager");
			Console.WriteLine("Deleted HKEY_CURRENT_USER\\SOFTWARE\\libertyernie\\BrawlStageManager.");
			if (libertyernie.SubKeyCount == 0) {
				Registry.CurrentUser.CreateSubKey("SOFTWARE").DeleteSubKey("libertyernie");
				Console.WriteLine("Deleted HKEY_CURRENT_USER\\SOFTWARE\\libertyernie.");
			}
		}
	}
}
