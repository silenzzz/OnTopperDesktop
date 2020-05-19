using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            listBoxProcesses.DisplayMember = "ProcessName";
            UpdateProcesses();
        }

        [DllImport("user32.dll")]       
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_SHOWWINDOW = 0x0040;

        private readonly SettingsForm settingsForm = new SettingsForm();
        private readonly AboutForm aboutForm = new AboutForm();

        private enum WINDOW_STATE { TOP, UNTOP }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            UpdateProcesses();
        }

        private void UpdateProcesses()
        {
            listBoxProcesses.BeginUpdate();
            listBoxProcesses.Items.Clear();
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
    }
}
