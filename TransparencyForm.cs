using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class TransparencyForm : Form
    {
        // TODO: Move functionality to main form???? idk pls pull request with normal solution
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_LAYERED = 0x80000;
        private const int LWA_ALPHA = 0x2;

        private Process process;

        public TransparencyForm()
        {
            InitializeComponent();
        }

        public void ShowDialogAndSetTransparency(Process p)
        {
            this.process = p;
            this.ShowDialog();
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            numericUpDown.Value = trackBar.Value;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            trackBar.Value = (int)numericUpDown.Value;
        }

        private void SetWindowTransparency(Process p, int transparency)
        {
            SetWindowLong(p.MainWindowHandle, GWL_EXSTYLE,
                GetWindowLong(p.MainWindowHandle, GWL_EXSTYLE) ^ WS_EX_LAYERED);
            SetLayeredWindowAttributes(p.MainWindowHandle, 0, (byte)((255 * transparency) / 100), LWA_ALPHA);
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            SetWindowTransparency(process, trackBar.Value);
            this.Close();
        }
    }
}
