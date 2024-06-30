using OnTopper.Properties;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class TransparencyForm : Form
    {
        public ushort Previous = 100;
        public ushort Current = 100;

        public TransparencyForm()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.LanguageAbbreviation.ToLower());
            InitializeComponent();
        }

        public void ShowDialogWithTopMostState(bool topMost)
        {
            TopMost = topMost;
            ShowDialog();
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            numericUpDown.Value = trackBar.Value;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            trackBar.Value = (int)numericUpDown.Value;
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            Previous = Current;
            Current = (ushort)trackBar.Value;
            
            Close();
        }
    }
}
