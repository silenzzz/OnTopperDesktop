using System.Windows.Forms;

namespace OnTopper
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(bool onTop)
        {
            InitializeComponent();
            TopMost = onTop;
        }

        public bool hideNonIntaractive = true;

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
