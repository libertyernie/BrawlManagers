using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;

namespace BrawlStageManager.RegistryUtilities {
	public static class FontSettings {
		private static TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));

		public static string WriteToRegistry(NameCreatorSettings settings) {
			if (settings == null) {
				Clear();
				return null;
			}
			string str = converter.ConvertToString(settings.Font);

			RegistryKey key = Registry.CurrentUser.CreateSubKey(GeneralRegistry.SUBKEY);
			key.SetValue("FrontStnameFont", str);
			key.SetValue("FrontStnameVerticalOffset", settings.VerticalOffset);
			return str;
		}

		public static NameCreatorSettings Get() {
			RegistryKey key = Registry.CurrentUser.CreateSubKey(GeneralRegistry.SUBKEY);
			object fontobj = key.GetValue("FrontStnameFont");
			object voobj = key.GetValue("FrontStnameVerticalOffset");
			if (voobj == null || fontobj == null) {
				return null;
			}
			int offset = Int32.Parse(voobj.ToString());
			return new NameCreatorSettings() {
				Font = (Font)converter.ConvertFromString(fontobj.ToString()),
				VerticalOffset = offset,
			};
		}

		private static void Clear() {
			RegistryKey key = Registry.CurrentUser.CreateSubKey(GeneralRegistry.SUBKEY);
			key.DeleteValue("FrontStnameFont", false);
			key.DeleteValue("FrontStnameVerticalOffset", false);
		}
	}
}
