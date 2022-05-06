using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace ModificationDetector.WinForm.Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modificationDetectingTextBox1.Text = "aaa";
            modificationDetectingTextBox2.Text = "bbb";
            modificationDetectingTextBox3.Text = "ccc";
            modificationDetectingTextBox4.Text = "ddd";
            modificationDetectingTextBox5.Text = string.Empty;

            modificationDetectingComboBox1.Items.Clear();
            modificationDetectingComboBox1.DataSource = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("aaa", -1),
                new KeyValuePair<string, int>("bbb", -2),
                new KeyValuePair<string, int>("ccc", -3),
            };
            modificationDetectingComboBox1.DisplayMember = "Key";
            modificationDetectingComboBox1.ValueMember = "Value";
            modificationDetectingComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            //modificationDetectingCheckBox1.Checked = true;

            controls = new IModificationDetectingControl[]
            {
                    modificationDetectingTextBox1,
                    modificationDetectingTextBox2,
                    modificationDetectingTextBox3,
                    modificationDetectingTextBox4,
                    modificationDetectingTextBox5,
                    modificationDetectingComboBox1,
                    modificationDetectingCheckBox1,
            };
#if true
            var o1 = Observable.FromEventPattern<ExactlyModifiedChangedEventArgs>(h => modificationDetectingTextBox1.ExactlyModifiedChanged += h, h => modificationDetectingTextBox1.ExactlyModifiedChanged -= h);
            var o2 = Observable.FromEventPattern<ExactlyModifiedChangedEventArgs>(h => modificationDetectingTextBox2.ExactlyModifiedChanged += h, h => modificationDetectingTextBox2.ExactlyModifiedChanged -= h);
            var o3 = Observable.FromEventPattern<ExactlyModifiedChangedEventArgs>(h => modificationDetectingTextBox3.ExactlyModifiedChanged += h, h => modificationDetectingTextBox3.ExactlyModifiedChanged -= h);
            var o4 = Observable.FromEventPattern<ExactlyModifiedChangedEventArgs>(h => modificationDetectingTextBox4.ExactlyModifiedChanged += h, h => modificationDetectingTextBox4.ExactlyModifiedChanged -= h);
            var o5 = Observable.FromEventPattern<ExactlyModifiedChangedEventArgs>(h => modificationDetectingTextBox5.ExactlyModifiedChanged += h, h => modificationDetectingTextBox5.ExactlyModifiedChanged -= h);
            var o6 = Observable.FromEventPattern<ExactlyModifiedChangedEventArgs>(h => modificationDetectingComboBox1.ExactlyModifiedChanged += h, h => modificationDetectingComboBox1.ExactlyModifiedChanged -= h);
            var o7 = Observable.FromEventPattern<ExactlyModifiedChangedEventArgs>(h => modificationDetectingCheckBox1.ExactlyModifiedChanged += h, h => modificationDetectingCheckBox1.ExactlyModifiedChanged -= h);

            Observable.CombineLatest(o1, o2, o3, o4, o5, o6, o7)
                .Select(s => s.Any(t => t.EventArgs.ExactlyModified ?? false))
                .Subscribe(b => lblStatus.Text = b ? "Modified" : "Not Modified");
#else
            var func = new EventHandler<ExactlyModifiedChangedEventArgs>((ss, ee) =>
            {
                lblStatus.Text = controls.Any(s => s.ExactlyModified ?? false) ? "Modified" : "Not Modified";
            });
            foreach (var c in controls)
            {
                c.ExactlyModifiedChanged += func;
            }
#endif

            btnStart.Enabled = true;
            btnRestart.Enabled = false;
            btnStop.Enabled = false;
            btnRestore.Enabled = false;

            lblStatus.Text = "Not Modified";
        }

        private IModificationDetectingControl[] controls;

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = btnRestart.Enabled = btnStop.Enabled = btnRestore.Enabled = false;
            Array.ForEach(controls, c => c.StartModificationDetecting());
            btnRestart.Enabled = btnStop.Enabled = btnRestore.Enabled = true;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = btnRestart.Enabled = btnStop.Enabled = btnRestore.Enabled = false;
            Array.ForEach(controls, c => c.RestartModificationDetecting());
            btnRestart.Enabled = btnStop.Enabled = btnRestore.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = btnRestart.Enabled = btnStop.Enabled = btnRestore.Enabled = false;
            Array.ForEach(controls, c => c.StopModificationDetecting());
            btnStart.Enabled = true;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = btnRestart.Enabled = btnStop.Enabled = btnRestore.Enabled = false;
            Array.ForEach(controls, c => c.Restore());
            btnRestart.Enabled = btnStop.Enabled = btnRestore.Enabled = true;
        }
    }
}
