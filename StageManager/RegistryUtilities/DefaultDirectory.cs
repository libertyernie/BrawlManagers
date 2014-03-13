using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;

namespace BrawlStageManager.RegistryUtilities {
	public class DefaultDirectory {
		public static void Set(string dir) {
			Registry.CurrentUser.CreateSubKey(GeneralRegistry.SUBKEY).SetValue("LastDirectory", dir);
			MessageBox.Show("The default directory for this program has been set to:\n" + dir);
		}

		public static string Get() {
			return (string)Registry.CurrentUser.CreateSubKey(GeneralRegistry.SUBKEY).GetValue("LastDirectory");
		}

		public static string GetIfExists() {
			string dir = Get();
			if (dir != null && !Directory.Exists(dir)) {
				MessageBox.Show("Note: The default directory (" + dir + ") does not exist.");
				return null;
			}
			return dir;
		}

		public static void Clear() {
			var key = Registry.CurrentUser.CreateSubKey(GeneralRegistry.SUBKEY);
			string removed = key.GetValue("LastDirectory").ToString();
			key.DeleteValue("LastDirectory");
			MessageBox.Show("The default directory (" + removed + ") has been cleared. From now on, this program will default to the folder it was started in.");
		}
	}
}
