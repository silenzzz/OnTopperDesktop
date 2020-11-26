namespace OnTopper
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.label = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.linkLabelSF = new System.Windows.Forms.LinkLabel();
            this.labelSF = new System.Windows.Forms.Label();
            this.linkLabelSFTicket = new System.Windows.Forms.LinkLabel();
            this.linkLabelGit = new System.Windows.Forms.LinkLabel();
            this.labelSFTicker = new System.Windows.Forms.Label();
            this.labelTrello = new System.Windows.Forms.Label();
            this.linkLabelTrello = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.Name = "label";
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // linkLabelSF
            // 
            resources.ApplyResources(this.linkLabelSF, "linkLabelSF");
            this.linkLabelSF.Name = "linkLabelSF";
            this.linkLabelSF.TabStop = true;
            this.linkLabelSF.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSF_LinkClicked);
            // 
            // labelSF
            // 
            resources.ApplyResources(this.labelSF, "labelSF");
            this.labelSF.Name = "labelSF";
            // 
            // linkLabelSFTicket
            // 
            resources.ApplyResources(this.linkLabelSFTicket, "linkLabelSFTicket");
            this.linkLabelSFTicket.Name = "linkLabelSFTicket";
            this.linkLabelSFTicket.TabStop = true;
            this.linkLabelSFTicket.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSFTicket_LinkClicked);
            // 
            // linkLabelGit
            // 
            resources.ApplyResources(this.linkLabelGit, "linkLabelGit");
            this.linkLabelGit.Name = "linkLabelGit";
            this.linkLabelGit.TabStop = true;
            this.linkLabelGit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelGit_LinkClicked);
            // 
            // labelSFTicker
            // 
            resources.ApplyResources(this.labelSFTicker, "labelSFTicker");
            this.labelSFTicker.Name = "labelSFTicker";
            // 
            // labelTrello
            // 
            resources.ApplyResources(this.labelTrello, "labelTrello");
            this.labelTrello.Name = "labelTrello";
            // 
            // linkLabelTrello
            // 
            resources.ApplyResources(this.linkLabelTrello, "linkLabelTrello");
            this.linkLabelTrello.Name = "linkLabelTrello";
            this.linkLabelTrello.TabStop = true;
            this.linkLabelTrello.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelTrello_LinkClicked);
            // 
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.linkLabelTrello);
            this.Controls.Add(this.labelTrello);
            this.Controls.Add(this.linkLabelGit);
            this.Controls.Add(this.labelSFTicker);
            this.Controls.Add(this.linkLabelSFTicket);
            this.Controls.Add(this.labelSF);
            this.Controls.Add(this.linkLabelSF);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.LinkLabel linkLabelSF;
        private System.Windows.Forms.Label labelSF;
        private System.Windows.Forms.LinkLabel linkLabelSFTicket;
        private System.Windows.Forms.LinkLabel linkLabelGit;
        private System.Windows.Forms.Label labelSFTicker;
        private System.Windows.Forms.Label labelTrello;
        private System.Windows.Forms.LinkLabel linkLabelTrello;
    }
}