using System;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class AboutForm : Form
    {
        public AboutForm(bool OnTop)
        {
            InitializeComponent();
            this.TopMost = OnTop;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
