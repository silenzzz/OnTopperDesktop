using Microsoft.Win32;
using OnTopper.Properties;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class SettingsForm : Form
    {
        // TODO: make private
        public bool hideNonIntaractive = true;
        public bool timerEnabled = false;
        public int interval = 3000;

        private const string APP_NAME = "OnTopper.exe";
        private const string DELETE_AUTORUN = "Dont enable on startup";
        private const string ADD_AUTORUN = "Enable on startup";

        public SettingsForm()
        {
            InitializeComponent();
            if (InAutorun())
            {
                checkBoxAutoHide.Visible = true;
                buttonAutorun.Text = DELETE_AUTORUN;
            }
            if (Settings.Default.AutoHide)
            {
                checkBoxAutoHide.Checked = true;
            }
        }

        #region STUFF

        public void ShowDialogWithTopMostState(bool onTop)
        {
            this.TopMost = onTop;
            ShowDialog();
        }

        private bool InAutorun()
        {
            var rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rkApp.GetValue(APP_NAME) == null)
                return false;
            else
                return true;
        }

        #endregion

        #region UI_SYS_EVENTS

        private void ButtonApply_Click(object sender, System.EventArgs e)
        {
            hideNonIntaractive = checkBoxHideUninteractive.Checked;
            timerEnabled = checkBoxAutoUpdate.Checked;
            interval = (int) numericUpDownInterval.Value;
            Close();
        }

        private void ButtonDefault_Click(object sender, System.EventArgs e)
        {
            checkBoxHideUninteractive.Checked = true;
        }

        private void ButtonAutorunOff_Click(object sender, System.EventArgs e)
        {
            var rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (InAutorun())
            {
                rkApp.DeleteValue(APP_NAME, false);
                MessageBox.Show("Deleted from autorun", "Autostart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBoxAutoHide.Visible = false;
                Settings.Default.AutoStart = false;
                buttonAutorun.Text = ADD_AUTORUN;
            }
            else
            {
                rkApp.SetValue(APP_NAME, Application.ExecutablePath.ToString());
                MessageBox.Show("Added to autorun", "Autostart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBoxAutoHide.Visible = true;
                Settings.Default.AutoStart = true;
                buttonAutorun.Text = DELETE_AUTORUN;
            }
            Settings.Default.Save();
        }

        private void CheckBoxAutoUpdate_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBoxAutoUpdate.Checked)
            {
                labelInterval.Visible = true;
                numericUpDownInterval.Visible = true;
            } else
            {
                labelInterval.Visible = false;
                numericUpDownInterval.Visible = false;
            }
        }

        private void CheckBoxAutoHide_CheckedChanged(object sender, System.EventArgs e)
        {
            Settings.Default.AutoHide = checkBoxAutoHide.Checked;
            Settings.Default.Save();
        }

        #endregion
    }
}
