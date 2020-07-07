using OnTopper.Stuff;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        public void ShowDialogWithTopMostState(bool onTop)
        {
            this.TopMost = onTop;
            ShowDialog();
        }

        public void AddAction(Action action)
        {
            listBoxActions.Items.Add(action);
        }

        private void ButtonRevert_Click(object sender, System.EventArgs e)
        {
            if (listBoxActions.SelectedIndex == -1)
            {
                return;
            }

            AddAction((listBoxActions.SelectedItem as Action).Revert());
            listBoxActions.SelectedIndex = listBoxActions.Items.Count - 1;
        }

        private void ButtonClear_Click(object sender, System.EventArgs e)
        {
            listBoxActions.Items.Clear();
        }
    }
}
