using System;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        public void ShowDialogWithTopMostState(bool onTop)
        {
            this.TopMost = onTop;
            ShowDialog();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
