using System.Windows.Forms;

namespace OnTopper
{
    public partial class SettingsForm : Form
    {
        public bool hideNonIntaractive = true;

        public SettingsForm()
        {
            InitializeComponent();
        }

        public void ShowDialogWithTopMostState(bool onTop)
        {
            this.TopMost = onTop;
            ShowDialog();
        }

        private void ButtonApply_Click(object sender, System.EventArgs e)
        {
            hideNonIntaractive = checkBoxHideUninteractive.Checked;
            Close();
        }

        private void ButtonDefault_Click(object sender, System.EventArgs e)
        {
            checkBoxHideUninteractive.Checked = true;
        }
    }
}
