using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class SizeForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nHeight, int nWidth, bool bRepaint);

        [DllImport("user32.dll")]
        public static extern long GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        private IntPtr handle;
        private Rectangle oldRectangle;

        public SizeForm()
        {
            InitializeComponent();
        }

        public void ShowDialogAndSetWindowSize(Process p, bool topMost)
        {
            this.TopMost = topMost;
            this.handle = p.MainWindowHandle;
            this.oldRectangle = new Rectangle();

            GetWindowRect(handle, ref this.oldRectangle);

            textBoxX.Text = oldRectangle.X.ToString();
            textBoxY.Text = oldRectangle.Y.ToString();
            textBoxHeight.Text = (oldRectangle.Height - oldRectangle.Y).ToString();
            textBoxWidth.Text = (oldRectangle.Width - oldRectangle.X).ToString();

            this.ShowDialog();
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxHeight.Text) || string.IsNullOrWhiteSpace(textBoxWidth.Text) || 
                string.IsNullOrWhiteSpace(textBoxX.Text) || string.IsNullOrWhiteSpace(textBoxY.Text))
            {
                MessageBox.Show("Set window height and width");
                return;
            }
            MoveWindow(handle, int.Parse(textBoxX.Text), int.Parse(textBoxY.Text), 
                int.Parse(textBoxHeight.Text), int.Parse(textBoxWidth.Text), true);
            Close();
        }

        private void TextBoxHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
