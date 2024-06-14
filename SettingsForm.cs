using DmLib.Autorun;
using OnTopper.Properties;
using OnTopper.Stuff;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using static DmLib.Autorun.Autorun;

namespace OnTopper
{
    public partial class SettingsForm : Form
    {
        // TODO: make private
        public bool hideNonIntaractive = true;
        public bool timerEnabled = false;
        public bool showWindowTitles = false;
        public int interval = 3000;

        private const string APP_NAME = "OnTopper.exe";
        private readonly string deleteFromAutorun = LocalizedMessageProvider.GetMessage("DELETE_AUTORUN");
        private readonly string addToAutorun = LocalizedMessageProvider.GetMessage("ADD_AUTORUN");

        private readonly Updater updater = new Updater();

        public SettingsForm()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.LanguageAbbreviation.ToLower());
            this.InitializeComponent();
            ApplyUiFromSettings();
            if (InAutorun())
            {
                checkBoxAutoHide.Visible = true;
                buttonAutorun.Text = deleteFromAutorun;
            }
            if (Settings.Default.AutoHide)
            {
                checkBoxAutoHide.Checked = true;
            }
        }

        private void ApplyUiFromSettings()
        {
            checkBoxAutoUpdate.Checked = Settings.Default.AutoUpdate;
            checkBoxAutoHide.Checked = Settings.Default.AutoHide;
            numericUpDownInterval.Value = Settings.Default.UpdateInterval;
            checkBoxShowWindowTitles.Checked = Settings.Default.WindowTitles;
            checkBoxHideUninteractive.Checked = Settings.Default.HideNonInteractive;
            comboBoxLanguage.SelectedItem = Settings.Default.Language;
        }

        public void ShowDialogWithTopMostState(bool onTop)
        {
            this.TopMost = onTop;
            ShowDialog();
        }

        private bool InAutorun()
        {
            return Autorun.Contains(APP_NAME, TARGET.USER);
        }

        private void ButtonApply_Click(object sender, System.EventArgs e)
        {
            hideNonIntaractive = checkBoxHideUninteractive.Checked;
            timerEnabled = checkBoxAutoUpdate.Checked;
            showWindowTitles = checkBoxShowWindowTitles.Checked;
            interval = (int)numericUpDownInterval.Value;

            if (comboBoxLanguage.SelectedItem.ToString() != Settings.Default.Language)
            {
                Application.Restart();
            }

            Close();
        }

        private void ButtonDefault_Click(object sender, System.EventArgs e)
        {
            checkBoxHideUninteractive.Checked = true;
        }

        private void ButtonAutorunOff_Click(object sender, System.EventArgs e)
        {
            if (InAutorun())
            {
                Autorun.Remove(APP_NAME, TARGET.USER);
                MessageBox.Show(LocalizedMessageProvider.GetMessage("DELETED_AUTORUN"),
                    LocalizedMessageProvider.GetMessage("AUTORUN"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBoxAutoHide.Visible = false;
                Settings.Default.AutoStart = false;
                buttonAutorun.Text = deleteFromAutorun;
            }
            else
            {
                Autorun.Add(APP_NAME, Application.ExecutablePath.ToString(), TARGET.USER);
                MessageBox.Show(LocalizedMessageProvider.GetMessage("ADDED_AUTORUN"),
                    LocalizedMessageProvider.GetMessage("AUTORUN"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBoxAutoHide.Visible = true;
                Settings.Default.AutoStart = true;
                buttonAutorun.Text = addToAutorun;
            }
            Settings.Default.Save();
        }

        private void CheckBoxAutoUpdate_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBoxAutoUpdate.Checked)
            {
                labelInterval.Visible = true;
                numericUpDownInterval.Visible = true;
            }
            else
            {
                labelInterval.Visible = false;
                numericUpDownInterval.Visible = false;
            }
        }

        private void ButtonCheckUpdates_Click(object sender, System.EventArgs e)
        {
            if (updater.UpdateAvaliable())
            {
                var result = MessageBox.Show(LocalizedMessageProvider.GetMessage("NEW_VERSION_AVAILABLE_QUESTION"),
                    LocalizedMessageProvider.GetMessage("UPDATE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    updater.InstallUpdate();
                }
            }
            else
            {
                MessageBox.Show(LocalizedMessageProvider.GetMessage("NO_UPDATE"),
                    LocalizedMessageProvider.GetMessage("UPDATE"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.AutoUpdate = checkBoxAutoUpdate.Checked;
            Settings.Default.AutoHide = checkBoxAutoHide.Checked;
            Settings.Default.UpdateInterval = (int)numericUpDownInterval.Value;
            Settings.Default.WindowTitles = checkBoxShowWindowTitles.Checked;
            Settings.Default.HideNonInteractive = checkBoxHideUninteractive.Checked;
            Settings.Default.Language = comboBoxLanguage.SelectedItem.ToString();
 
            Settings.Default.Save();
        }
    }
}
