using DmLib.Window;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class TransparencyForm : Form
    {
        private Process process;

        public TransparencyForm()
        {
            InitializeComponent();
        }

        public void ShowDialogAndSetTransparency(Process p, bool topMost)
        {
            this.TopMost = topMost;
            this.process = p;
            this.ShowDialog();
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
            Transparency.SetWindowTransparency(process, trackBar.Value);
            this.Close();
        }
    }
}
