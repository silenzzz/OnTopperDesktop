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
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(326, 91);
            this.label.TabIndex = 0;
            this.label.Text = resources.GetString("label.Text");
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(12, 211);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(326, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Ok";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // linkLabelSF
            // 
            this.linkLabelSF.AutoSize = true;
            this.linkLabelSF.Location = new System.Drawing.Point(70, 100);
            this.linkLabelSF.Name = "linkLabelSF";
            this.linkLabelSF.Size = new System.Drawing.Size(211, 13);
            this.linkLabelSF.TabIndex = 2;
            this.linkLabelSF.TabStop = true;
            this.linkLabelSF.Text = "https://sourceforge.net/projects/ontopper/";
            this.linkLabelSF.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSF_LinkClicked);
            // 
            // labelSF
            // 
            this.labelSF.AutoSize = true;
            this.labelSF.Location = new System.Drawing.Point(36, 116);
            this.labelSF.Name = "labelSF";
            this.labelSF.Size = new System.Drawing.Size(286, 13);
            this.labelSF.TabIndex = 3;
            this.labelSF.Text = "If you want to report bug or suggest something leave it here\r\n";
            // 
            // linkLabelSFTicket
            // 
            this.linkLabelSFTicket.AutoSize = true;
            this.linkLabelSFTicket.Location = new System.Drawing.Point(59, 129);
            this.linkLabelSFTicket.Name = "linkLabelSFTicket";
            this.linkLabelSFTicket.Size = new System.Drawing.Size(241, 13);
            this.linkLabelSFTicket.TabIndex = 4;
            this.linkLabelSFTicket.TabStop = true;
            this.linkLabelSFTicket.Text = "https://sourceforge.net/p/ontopper/tickets/new/";
            this.linkLabelSFTicket.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSFTicket_LinkClicked);
            // 
            // linkLabelGit
            // 
            this.linkLabelGit.AutoSize = true;
            this.linkLabelGit.Location = new System.Drawing.Point(55, 159);
            this.linkLabelGit.Name = "linkLabelGit";
            this.linkLabelGit.Size = new System.Drawing.Size(243, 13);
            this.linkLabelGit.TabIndex = 6;
            this.linkLabelGit.TabStop = true;
            this.linkLabelGit.Text = "https://github.com/DeMmAge/OnTopperDesktop\r\n";
            this.linkLabelGit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelGit_LinkClicked);
            // 
            // labelSFTicker
            // 
            this.labelSFTicker.AutoSize = true;
            this.labelSFTicker.Location = new System.Drawing.Point(67, 146);
            this.labelSFTicker.Name = "labelSFTicker";
            this.labelSFTicker.Size = new System.Drawing.Size(224, 13);
            this.labelSFTicker.TabIndex = 5;
            this.labelSFTicker.Text = "Source here (pull request or ticket will be nice)";
            // 
            // labelTrello
            // 
            this.labelTrello.AutoSize = true;
            this.labelTrello.Location = new System.Drawing.Point(138, 174);
            this.labelTrello.Name = "labelTrello";
            this.labelTrello.Size = new System.Drawing.Size(77, 13);
            this.labelTrello.TabIndex = 7;
            this.labelTrello.Text = "Roadmap here";
            // 
            // linkLabelTrello
            // 
            this.linkLabelTrello.AutoSize = true;
            this.linkLabelTrello.Location = new System.Drawing.Point(100, 187);
            this.linkLabelTrello.Name = "linkLabelTrello";
            this.linkLabelTrello.Size = new System.Drawing.Size(153, 13);
            this.linkLabelTrello.TabIndex = 8;
            this.linkLabelTrello.TabStop = true;
            this.linkLabelTrello.Text = "https://trello.com/b/DjuPzweK";
            this.linkLabelTrello.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelTrello_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(344, 246);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
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