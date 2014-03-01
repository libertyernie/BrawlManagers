using BrawlManagerLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSSEditor {
	public partial class AskSwapDialog : Form {
		private bool listUpdateInProgress;

		private class Wrapper {
			public StagePairControl spc;
			public override string ToString() {
				return String.Format("{0:X2} ({0:D2}) - {1}",
					(int)spc.NUDDefValue, StageIDMap.PacBasenameForStageID(spc.Stage));
			}
		}
		private Dictionary<decimal, Wrapper> dict = new Dictionary<decimal, Wrapper>();

		public StagePairControl Selected {
			get {
				return ((Wrapper)comboBox1.SelectedItem).spc;
			}
		}

		public AskSwapDialog() {
			InitializeComponent();
			listUpdateInProgress = false;
			this.Shown += (o, e) => {
				if (comboBox1.SelectedItem == null) comboBox1.SelectedIndex = 0;
			};
		}

		public void Add(StagePairControl spc) {
			Wrapper w = new Wrapper() { spc = spc };
			comboBox1.Items.Add(w);
			dict.Add(spc.NUDDefValue, w);
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
			if (listUpdateInProgress) return;
			//Console.WriteLine("n1");

			listUpdateInProgress = true;
			numericUpDown2.Value = numericUpDown1.Value;
			if (dict.ContainsKey(numericUpDown1.Value)) comboBox1.SelectedItem = dict[numericUpDown1.Value];
			listUpdateInProgress = false;
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e) {
			if (listUpdateInProgress) return;
			//Console.WriteLine("n2");

			listUpdateInProgress = true;
			numericUpDown1.Value = numericUpDown2.Value;
			if (dict.ContainsKey(numericUpDown2.Value)) comboBox1.SelectedItem = dict[numericUpDown2.Value];
			listUpdateInProgress = false;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			if (listUpdateInProgress) return;
			//Console.WriteLine("c1");

			listUpdateInProgress = true;
			numericUpDown1.Value = numericUpDown2.Value = ((Wrapper)comboBox1.SelectedItem).spc.NUDDefValue;
			listUpdateInProgress = false;
		}
	}
}
