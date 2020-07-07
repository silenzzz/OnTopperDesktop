﻿using DmLib.Window;
using OnTopper.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class MainForm : Form
    {
        private readonly SettingsForm settingsForm = new SettingsForm();
        private readonly AboutForm aboutForm = new AboutForm();
        private readonly TransparencyForm transparencyForm = new TransparencyForm();
        private readonly SizeForm sizeForm = new SizeForm();

        private bool ballonShowed = false;

        public MainForm()
        {
            InitializeComponent();
            // TODO: store only machine name field in listbox
            listBoxProcesses.DisplayMember = "ProcessName";
            SetNotifyIcon();
            UpdateProcesses();
        }

        #region STUFF

        private void SetWindowState(State.WINDOW_STATE state)
        {
            try
            {
                State.SetWindowState((Process)listBoxProcesses.SelectedItem, state);
            }
            catch (ProcessNotExistsException)
            {
                MessageBox.Show("Process doesn't exists anymore",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateProcesses();
            }
        }

        private string GetProcessNameByIndex(int index)
        {
            try
            {
                return ((Process)listBoxProcesses.Items[index]).ProcessName;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool HasMainWindow(Process p)
        {
            return p.MainWindowHandle != IntPtr.Zero;
        }

        private bool InAutoRunAndMinimized()
        {
            return Settings.Default.AutoHide && Settings.Default.AutoStart;
        }

        private void UpdateProcesses()
        {
            int selected = listBoxProcesses.SelectedIndex;
            // TODO: maybe rewrite
            string selectedName = GetProcessNameByIndex(selected);
            listBoxProcesses.BeginUpdate();
            listBoxProcesses.Items.Clear();
            // TODO: optimize
            foreach (var process in Process.GetProcesses())
            {
                if (settingsForm.hideNonIntaractive)
                {
                    if (HasMainWindow(process))
                    {
                        listBoxProcesses.Items.Add(process);
                    }
                }
                else
                {
                    listBoxProcesses.Items.Add(process);
                }
            }
            listBoxProcesses.EndUpdate();
            if (selected != -1)
            {
                if (selectedName.Equals(GetProcessNameByIndex(selected)))
                {
                    listBoxProcesses.SelectedIndex = selected;
                }
            }
        }

        private void ShowSelectProcessMessageBox()
        {
            MessageBox.Show("Select process first", "OnTopper", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        #endregion

        #region UI_SETUP

        private void SetNotifyIcon()
        {
            ContextMenu iconMenu = new ContextMenu();
            MenuItem openItem = new MenuItem("&Open");
            MenuItem hideItem = new MenuItem("&Hide in task bar");
            if (InAutoRunAndMinimized())
            {
                hideItem.Checked = true;
            }
            MenuItem closeItem = new MenuItem("&Close");

            var handler = new EventHandler(OnClickIconMenuItem);
            openItem.Click += handler;
            hideItem.Click += handler;
            closeItem.Click += handler;
            iconMenu.MenuItems.Add(openItem);
            iconMenu.MenuItems.Add(hideItem);
            iconMenu.MenuItems.Add(closeItem);

            notifyIcon.Text = "OnTopper";
            notifyIcon.BalloonTipTitle = "OnTopper minimized";
            notifyIcon.BalloonTipText = "OnTopper has been minimized, right click on the icon below to open";
            notifyIcon.ContextMenu = iconMenu;
        }

        #endregion

        #region UI_CONFIGURE

        private bool ToggleTaskbarVisibility()
        {
            if (this.ShowInTaskbar)
            {
                this.ShowInTaskbar = false;
            }
            else
            {
                this.ShowInTaskbar = true;
            }
            return !this.ShowInTaskbar;
        }

        #endregion

        #region UI_SYS_EVENTS

        private void OnClickIconMenuItem(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            string text = item.Text;
            // TODO: rewrite этот бля поиск по строке
            if (text.Equals("&Open"))
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (text.Equals("&Hide in task bar"))
            {
                item.Checked = ToggleTaskbarVisibility();
            }
            else if (text.Equals("&Close"))
            {
                this.Close();
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
            SetWindowState(State.WINDOW_STATE.TOP);
        }

        private void ButtonUnsetTop_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                ShowSelectProcessMessageBox();
                return;
            }
            SetWindowState(State.WINDOW_STATE.UNTOP);
        }

        private void ButtonThisOnTop_Click(object sender, EventArgs e)
        {
            if (TopMost)
            {
                buttonThisOnTop.Text = "Set this";
                TopMost = false;
            }
            else
            {
                buttonThisOnTop.Text = "Unset this";
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
            if (settingsForm.showWindowTitles)
            {
                listBoxProcesses.DisplayMember = "MainWindowTitle";
            } else
            {
                listBoxProcesses.DisplayMember = "ProcessName";
            }
            if (settingsForm.timerEnabled)
            {
                timer.Interval = settingsForm.interval;
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
            int index = listBoxProcesses.FindString(textBoxSearch.Text);
            if (index != -1)
            {
                listBoxProcesses.SelectedIndex = index;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                if (!ballonShowed)
                {
                    notifyIcon.ShowBalloonTip(5000);
                    ballonShowed = true;
                }
            }
            else if (this.WindowState == FormWindowState.Maximized ||
                this.WindowState == FormWindowState.Normal)
            {
                notifyIcon.Visible = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateProcesses();
        }

        private void ListBoxProcesses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxProcesses.SelectedIndex;
            if (index != -1)
            {
                try
                {
                    var proc = (Process)listBoxProcesses.Items[index];
                    MessageBox.Show(string.Format("Priority: {0}\nId: {1}\nName: {2}\nResponding: {3}\nStarted: {4}\n" +
                        "Threads: {5}\nTop most: {6}\nVirtual mem size: {7}b", proc.BasePriority, proc.Id, proc.ProcessName,
                        proc.Responding, proc.StartTime, proc.Threads.Count, State.IsTopMost(proc), proc.VirtualMemorySize64),
                        "Process info");
                }
                catch (Exception)
                {
                    UpdateProcesses();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (InAutoRunAndMinimized())
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void ButtonTransparency_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                ShowSelectProcessMessageBox();
                return;
            }
            transparencyForm.ShowDialogAndSetTransparency((Process)listBoxProcesses.SelectedItem, this.TopMost);
        }

        private void ButtonProperties_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                ShowSelectProcessMessageBox();
                return;
            }
            sizeForm.ShowDialogAndSetWindowSize((Process)listBoxProcesses.SelectedItem, this.TopMost);
        }

        #endregion
    }
}
