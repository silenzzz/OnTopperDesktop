using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            listBoxProcesses.DisplayMember = "ProcessName";
            update();
        }

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOMOVE = 0x0002;
        const uint SWP_SHOWWINDOW = 0x0040;

        private enum WINDOW_STATE { TOP, UNTOP }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            listBoxProcesses.Items.Clear();
            foreach (var process in Process.GetProcesses())
            {
                listBoxProcesses.Items.Add(process);
            }
        }

        private void ButtonSetTop_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                labelSelectProcess.Show();
                return;
            }
            labelSelectProcess.Hide();
            setWindowState(WINDOW_STATE.TOP);
        }

        private void ButtonUnsetTop_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                labelSelectProcess.Show();
                return;
            }
            labelSelectProcess.Hide();
            setWindowState(WINDOW_STATE.UNTOP);
        }

        private void setWindowState(WINDOW_STATE state)
        {
            try
            {
                if (state == WINDOW_STATE.TOP)
                {
                    SetWindowPos(getWindowHandle((Process)listBoxProcesses.SelectedItem)
                    , HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                }
                else
                {
                    SetWindowPos(getWindowHandle((Process)listBoxProcesses.SelectedItem)
                    , HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Process does not exists anymore",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                update();
            }
        }

        private IntPtr getWindowHandle(Process p)
        {
            return Process.GetProcessById(p.Id).MainWindowHandle;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            int id = listBoxProcesses.FindString(textBoxSearch.Text);
            if (id != -1)
            {
                listBoxProcesses.SelectedIndex = id;
            }
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
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }
    }
}
