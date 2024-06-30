using DmLib.Window;
using OnTopper.Properties;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using OnTopper.Util;
using Action = OnTopper.Util.Action;

namespace OnTopper
{
    public partial class MainForm : Form
    {
        private readonly SettingsForm settingsForm = new SettingsForm();
        private readonly AboutForm aboutForm = new AboutForm();
        private readonly TransparencyForm transparencyForm = new TransparencyForm();
        private readonly SizeForm sizeForm = new SizeForm();
        private readonly LogForm logForm = new LogForm();

        private bool balloonShowed;

        private State.WINDOW_STATE newState;
        private readonly Settings settings = Settings.Default;

        public MainForm()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.LanguageAbbreviation.ToLower());
            Controls.Clear();
            InitializeComponent();
            listBoxProcesses.DisplayMember = "ProcessName";
            SetNotifyIcon();
            UpdateProcesses();

            var updateService = UpdateService.GetInstance();
            if (!updateService.UpdateAvailable()) return;
            var res = MessageBox.Show(
                $"New version {updateService.GetWebVersion()} is available, want to install it now?",
                "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res != DialogResult.Yes) return;

            updateService.UpdateDownloaded += OnUpdateDownloaded;
            updateService.DownloadUpdate();
        }

        private static void OnUpdateDownloaded(object sender, EventArgs e)
        {
            MessageBox.Show("Update downloaded, want to restart now?", "Update", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

        private void AddActionToLogForm(Action action)
        {
            logForm.AddAction(action);
        }

        private void SetWindowState(State.WINDOW_STATE state)
        {
            try
            {
                State.SetWindowState((Process) listBoxProcesses.SelectedItem, state);
            }
            catch (ProcessNotExistsException)
            {
                MessageBox.Show(LocalizedMessageProvider.GetMessage("PROCESS_DOESNT_EXISTS"),
                    LocalizedMessageProvider.GetMessage("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateProcesses();
            }
        }

        private string GetProcessNameByIndex(int index)
        {
            try
            {
                return ((Process) listBoxProcesses.Items[index]).ProcessName;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool InAutoRunAndMinimized()
        {
            return settings.AutoHide && settings.AutoStart;
        }

        private void UpdateProcesses()
        {
            var selected = listBoxProcesses.SelectedIndex;
            var selectedName = GetProcessNameByIndex(selected);

            listBoxProcesses.BeginUpdate();
            listBoxProcesses.Items.Clear();
            
            foreach (var process in Process.GetProcesses())
            {
                if (settingsForm.HideNonInteractive)
                {
                    if (!State.HasMainWindow(process)) continue;
                    listBoxProcesses.Items.Add(process);
                    continue;
                }

                listBoxProcesses.Items.Add(process);
            }

            listBoxProcesses.EndUpdate();

            if (selected == -1) return;

            if (selectedName.Equals(GetProcessNameByIndex(selected)))
            {
                listBoxProcesses.SelectedIndex = selected;
            }
        }

        private static void ShowSelectProcessMessageBox()
        {
            MessageBox.Show(LocalizedMessageProvider.GetMessage("SELECT_PROCESS"),
                LocalizedMessageProvider.GetMessage("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void SetNotifyIcon()
        {
            var iconMenu = new ContextMenu();
            var openItem = new MenuItem(LocalizedMessageProvider.GetMessage("OPEN"));
            var hideItem = new MenuItem(LocalizedMessageProvider.GetMessage("HIDE_IN_TASKBAR"));
            if (InAutoRunAndMinimized())
            {
                hideItem.Checked = true;
            }

            var closeItem = new MenuItem(LocalizedMessageProvider.GetMessage("CLOSE"));

            var handler = new EventHandler(OnClickIconMenuItem);
            openItem.Click += handler;
            hideItem.Click += handler;
            closeItem.Click += handler;
            iconMenu.MenuItems.Add(openItem);
            iconMenu.MenuItems.Add(hideItem);
            iconMenu.MenuItems.Add(closeItem);

            notifyIcon.Text = "OnTopper";
            notifyIcon.BalloonTipTitle = LocalizedMessageProvider.GetMessage("MINIMIZED");
            notifyIcon.BalloonTipText = LocalizedMessageProvider.GetMessage("MINIMIZED_RIGHT_CLICK");
            notifyIcon.ContextMenu = iconMenu;
        }

        private bool ToggleTaskbarVisibility()
        {
            ShowInTaskbar = !ShowInTaskbar;
            return !ShowInTaskbar;
        }

        private void OnClickIconMenuItem(object sender, EventArgs e)
        {
            if (!(sender is MenuItem item)) return;
            var text = item.Text;

            if (text.Equals(LocalizedMessageProvider.GetMessage("OPEN")))
            {
                WindowState = FormWindowState.Normal;
            }
            else if (text.Equals(LocalizedMessageProvider.GetMessage("HIDE_IN_TASKBAR")))
            {
                item.Checked = ToggleTaskbarVisibility();
            }
            else if (text.Equals(LocalizedMessageProvider.GetMessage("CLOSE")))
            {
                Close();
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            UpdateProcesses();
        }

        private void ButtonSetTop_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                ShowSelectProcessMessageBox();
                return;
            }

            SetWindowState(newState);

            logForm.AddAction(newState == State.WINDOW_STATE.TOP
                ? new TopStateAction(listBoxProcesses.SelectedItem as Process, State.WINDOW_STATE.TOP)
                : new TopStateAction(listBoxProcesses.SelectedItem as Process, State.WINDOW_STATE.UNTOP));

            newState = newState == State.WINDOW_STATE.TOP ? State.WINDOW_STATE.UNTOP : State.WINDOW_STATE.TOP;
            RefreshTopButton();
        }

        private void ButtonThisOnTop_Click(object sender, EventArgs e)
        {
            if (TopMost)
            {
                buttonThisOnTop.Text = LocalizedMessageProvider.GetMessage("SET_THIS");
                TopMost = false;
            }
            else
            {
                buttonThisOnTop.Text = LocalizedMessageProvider.GetMessage("UNSET_THIS");
                TopMost = true;
            }
        }

        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            aboutForm.ShowDialogWithTopMostState(TopMost);
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialogWithTopMostState(TopMost);
            listBoxProcesses.DisplayMember = settingsForm.ShowWindowTitles ? "MainWindowTitle" : "ProcessName";
            if (settingsForm.TimerEnabled)
            {
                timer.Interval = settingsForm.Interval;
                timer.Start();
            }
            else
            {
                timer.Stop();
            }

            UpdateProcesses();
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var index = listBoxProcesses.FindString(textBoxSearch.Text);
            if (index != -1)
            {
                listBoxProcesses.SelectedIndex = index;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                {
                    notifyIcon.Visible = true;
                    if (!balloonShowed)
                    {
                        notifyIcon.ShowBalloonTip(5000);
                        balloonShowed = true;
                    }

                    break;
                }
                case FormWindowState.Maximized:
                case FormWindowState.Normal:
                    notifyIcon.Visible = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateProcesses();
        }

        private void ListBoxProcesses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = listBoxProcesses.SelectedIndex;
            if (index == -1) return;
            try
            {
                var proc = (Process) listBoxProcesses.Items[index];
                MessageBox.Show(
                    $"Priority: {proc.BasePriority}\n" +
                    $"Id: {proc.Id}\nName: {proc.ProcessName}\n" +
                    $"Responding: {proc.Responding}\n" +
                    $"Started: {proc.StartTime}\n" +
                    $"Top most: {State.IsTopMost(proc)}",
                    "Process info");
            }
            catch (Exception)
            {
                UpdateProcesses();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (InAutoRunAndMinimized())
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
            else
            {
                var updater = new Updater();
                if (!updater.UpdateAvailable() || !settings.UpdateVersion) return;
                var result = MessageBox.Show(LocalizedMessageProvider.GetMessage("NEW_VERSION_AVAILABLE_QUESTION"),
                    LocalizedMessageProvider.GetMessage("UPDATE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Updater.InstallUpdate();
                    return;
                }

                settings.UpdateVersion = false;
                settings.Save();
            }
        }

        private void ButtonTransparency_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                ShowSelectProcessMessageBox();
                return;
            }

            transparencyForm.ShowDialogWithTopMostState(TopMost);
            var p = listBoxProcesses.SelectedItem as Process;
            Transparency.SetWindowTransparency(p, transparencyForm.Current);
            AddActionToLogForm(new OpacityAction(transparencyForm.Previous, transparencyForm.Current, p));
        }

        private void ButtonProperties_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                ShowSelectProcessMessageBox();
                return;
            }

            sizeForm.ShowDialogAndSetWindowSize((Process) listBoxProcesses.SelectedItem, this.TopMost);
        }

        private void ButtonLog_Click(object sender, EventArgs e)
        {
            logForm.ShowDialogWithTopMostState(State.IsTopMost(Process.GetCurrentProcess()));
            UpdateProcesses();
            RefreshTopButton();
        }

        private void ListBoxProcesses_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedIndex == -1)
            {
                ShowSelectProcessMessageBox();
                return;
            }

            var proc = listBoxProcesses.SelectedItem as Process;
            newState = !State.IsTopMost(proc) ? State.WINDOW_STATE.TOP : State.WINDOW_STATE.UNTOP;
            RefreshTopButton();
        }

        private void RefreshTopButton()
        {
            buttonSetTop.Text =
                LocalizedMessageProvider.GetMessage(newState == State.WINDOW_STATE.TOP ? "SET_TOP" : "UNSET_TOP");
        }
    }
}