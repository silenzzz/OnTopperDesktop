using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_SHOWWINDOW = 0x0040;

        private readonly SettingsForm settingsForm = new SettingsForm();
        private readonly AboutForm aboutForm = new AboutForm();

        private bool ballonShowed = false;

        private enum WINDOW_STATE { TOP, UNTOP }

        public MainForm()
        {
            InitializeComponent();
            listBoxProcesses.DisplayMember = "ProcessName";
            SetNotifyIcon();
            UpdateProcesses();
        }

        private void SetNotifyIcon()
        {
            ContextMenu iconMenu = new ContextMenu();
            MenuItem openItem = new MenuItem("&Open");
            MenuItem hideItem = new MenuItem("&Hide in task bar");
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

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            UpdateProcesses();
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

        private void ButtonSetTop_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                labelSelectProcess.Show();
                return;
            }
            labelSelectProcess.Hide();
            SetWindowState(WINDOW_STATE.TOP);
        }

        private void ButtonUnsetTop_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                labelSelectProcess.Show();
                return;
            }
            labelSelectProcess.Hide();
            SetWindowState(WINDOW_STATE.UNTOP);
        }

        private void SetWindowState(WINDOW_STATE state)
        {
            try
            {
                if (state == WINDOW_STATE.TOP)
                {
                    SetWindowPos(GetWindowHandle((Process)listBoxProcesses.SelectedItem)
                    , HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                }
                else
                {
                    SetWindowPos(GetWindowHandle((Process)listBoxProcesses.SelectedItem)
                    , HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Process doesn't exists anymore",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateProcesses();
            }
        }

        private IntPtr GetWindowHandle(Process p)
        {
            return Process.GetProcessById(p.Id).MainWindowHandle;
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
            if (settingsForm.timerEnabled)
            {
                timer.Interval = settingsForm.interval;
                timer.Start();
            } else
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
    }
}
