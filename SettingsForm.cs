using DmLib.Autorun;
using OnTopper.Properties;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using OnTopper.Util;
using static DmLib.Autorun.Autorun;

namespace OnTopper
{
    public partial class SettingsForm : Form
    {
        public bool HideNonInteractive = true;
        public bool TimerEnabled;
        public bool ShowWindowTitles;
        public int Interval = 3000;

        private const string AppName = "OnTopper.exe";
        private readonly string deleteFromAutorun = LocalizedMessageProvider.GetMessage("DELETE_AUTORUN");
        private readonly string addToAutorun = LocalizedMessageProvider.GetMessage("ADD_AUTORUN");

        private readonly Updater updater = new Updater();
        private readonly Settings settings = Settings.Default;

        public SettingsForm()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.LanguageAbbreviation.ToLower());
            InitializeComponent();
            ApplyUiFromSettings();
            
            if (InAutorun())
            {
                checkBoxAutoHide.Visible = true;
                buttonAutorun.Text = deleteFromAutorun;
            }
            
            if (settings.AutoHide)
            {
                checkBoxAutoHide.Checked = true;
            }
        }

        private void ApplyUiFromSettings()
        {
            checkBoxAutoUpdate.Checked = settings.AutoUpdate;
            checkBoxAutoHide.Checked = settings.AutoHide;
            numericUpDownInterval.Value = settings.UpdateInterval;
            checkBoxShowWindowTitles.Checked = settings.WindowTitles;
            checkBoxHideUninteractive.Checked = settings.HideNonInteractive;
            comboBoxLanguage.SelectedItem = settings.Language;
        }

        public void ShowDialogWithTopMostState(bool onTop)
        {
            TopMost = onTop;
            ShowDialog();
        }

        private static bool InAutorun()
        {
            return Autorun.Contains(AppName, TARGET.USER);
        }

        private void ButtonApply_Click(object sender, System.EventArgs e)
        {
            HideNonInteractive = checkBoxHideUninteractive.Checked;
            TimerEnabled = checkBoxAutoUpdate.Checked;
            ShowWindowTitles = checkBoxShowWindowTitles.Checked;
            Interval = (int)numericUpDownInterval.Value;

            if (comboBoxLanguage.SelectedItem.ToString() != settings.Language)
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
                Remove(AppName, TARGET.USER);
                MessageBox.Show(LocalizedMessageProvider.GetMessage("DELETED_AUTORUN"),
                    LocalizedMessageProvider.GetMessage("AUTORUN"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBoxAutoHide.Visible = false;
                settings.AutoStart = false;
                buttonAutorun.Text = deleteFromAutorun;
            }
            else
            {
                Add(AppName, Application.ExecutablePath, TARGET.USER);
                MessageBox.Show(LocalizedMessageProvider.GetMessage("ADDED_AUTORUN"),
                    LocalizedMessageProvider.GetMessage("AUTORUN"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBoxAutoHide.Visible = true;
                settings.AutoStart = true;
                buttonAutorun.Text = addToAutorun;
            }
            settings.Save();
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
            if (updater.UpdateAvailable())
            {
                var result = MessageBox.Show(LocalizedMessageProvider.GetMessage("NEW_VERSION_AVAILABLE_QUESTION"),
                    LocalizedMessageProvider.GetMessage("UPDATE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Updater.InstallUpdate();
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
            settings.AutoUpdate = checkBoxAutoUpdate.Checked;
            settings.AutoHide = checkBoxAutoHide.Checked;
            settings.UpdateInterval = (int)numericUpDownInterval.Value;
            settings.WindowTitles = checkBoxShowWindowTitles.Checked;
            settings.HideNonInteractive = checkBoxHideUninteractive.Checked;
            settings.Language = comboBoxLanguage.SelectedItem.ToString();
 
            settings.Save();
        }
    }
}
