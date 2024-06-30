using OnTopper.Properties;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OnTopper
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.LanguageAbbreviation.ToLower());
            InitializeComponent();
            label.Text = string.Format(label.Text, typeof(Program).Assembly.GetName().Version);
        }

        public void ShowDialogWithTopMostState(bool onTop)
        {
            TopMost = onTop;
            ShowDialog();
        }

        private void LinkLabelSF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabelSF.Text);
        }

        private void LinkLabelSFTicket_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabelSFTicket.Text);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LinkLabelGit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabelGit.Text);
        }

        private void LinkLabelTrello_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabelTrello.Text);
        }
    }
}
