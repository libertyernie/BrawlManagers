using BrawlLib.SSBB;
using BrawlManagerLib;
using Newtonsoft.Json;
using RazorEngine.Templating;
using RazorEngine.Text;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SSSEditor {
    /// <summary>
    /// cshtml base class. Only exists for Intellisense.
    /// </summary>
    public class PairListPageBase : TemplateBase<PairListModel> {
        public new PairListModel Model {
            get {
                return base.Model;
            }
            set {
                base.Model = value;
            }
        }
        public new object Raw(string rawString) {
            return base.Raw(rawString);
        }
    }

    public class PairListModel {
        public Stage[] stages { get; set; }
		public byte[][] icons { get; set; }
		public Song[] songsByStage { get; set; }
        public List<ModelPair> pairs { get; set; }
		public byte[] screen1 { get; set; }
		public byte[] screen2 { get; set; }

        public PairListModel() {
            icons = new byte[256][];
			songsByStage = new Song[256];
            pairs = new List<ModelPair>();
			stages = StageIDMap.Stages;
        }

        public string iconsJSON {
            get {
                return JsonConvert.SerializeObject(icons);
            }
        }

		public string songsByStageJSON {
			get {
				return JsonConvert.SerializeObject(songsByStage);
			}
		}

		public static ReadOnlyCollection<KeyValuePair<byte, string>> StagesByID {
			get {
				return StageIDMap.StagesByID;
			}
		}
	}

    public class ModelPair {
        public int origId { get; set; }
        public byte stage { get; set; }
        public byte icon { get; set; }
    }
}
