using DmLib.Window;
using OnTopper.Stuff;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class SizeForm : Form
    {
        private Process process;
        private Rectangle oldRectangle;

        public SizeForm()
        {
            InitializeComponent();
        }

        public void ShowDialogAndSetWindowSize(Process p, bool topMost)
        {
            this.TopMost = topMost;
            this.process = p;
            this.oldRectangle = Borders.GetWindowRectangle(p);

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
                MessageBox.Show(LocalizedMessageProvider.GetMessage("SET_HEIGHT_WIDTH"),
                    LocalizedMessageProvider.GetMessage("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Borders.EditWindow(process, int.Parse(textBoxX.Text), int.Parse(textBoxY.Text),
                int.Parse(textBoxHeight.Text), int.Parse(textBoxWidth.Text));
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
