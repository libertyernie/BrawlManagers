using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SSSEditor {
    public class Resources {
        public static string PairList {
            get {
                return GetEmbeddedResource("SSSEditor.PairList.cshtml");
            }
        }

        public static string About {
            get {
                return GetEmbeddedResource("SSSEditor.About.html");
            }
        }

        public static string JQuery {
            get {
                return GetEmbeddedResource("SSSEditor.jquery.min.js");
            }
        }

        private static string GetEmbeddedResource(string fullname) {
            Assembly a = Assembly.GetAssembly(typeof(Resources));
            string[] ssd = a.GetManifestResourceNames();
            using (Stream stream = a.GetManifestResourceStream(fullname)) {
                using (StreamReader reader = new StreamReader(stream)) {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
