using System;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            label.Text = string.Format(label.Text, typeof(Program).Assembly.GetName().Version.ToString());
        }

        public void ShowDialogWithTopMostState(bool onTop)
        {
            this.TopMost = onTop;
            ShowDialog();
        }

        #region UI_SYS_EVENTS

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
