namespace OnTopper
{
    partial class LogForm
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
            this.listBoxActions = new System.Windows.Forms.ListBox();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxActions
            // 
            this.listBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxActions.FormattingEnabled = true;
            this.listBoxActions.Location = new System.Drawing.Point(12, 12);
            this.listBoxActions.Name = "listBoxActions";
            this.listBoxActions.Size = new System.Drawing.Size(310, 147);
            this.listBoxActions.TabIndex = 0;
            // 
            // buttonRevert
            // 
            this.buttonRevert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRevert.Location = new System.Drawing.Point(75, 165);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(247, 23);
            this.buttonRevert.TabIndex = 1;
            this.buttonRevert.Text = "Revert selected";
            this.buttonRevert.UseVisualStyleBackColor = true;
            this.buttonRevert.Click += new System.EventHandler(this.ButtonRevert_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClear.Location = new System.Drawing.Point(12, 165);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(57, 23);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 193);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonRevert);
            this.Controls.Add(this.listBoxActions);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 232);
            this.Name = "LogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxActions;
        private System.Windows.Forms.Button buttonRevert;
        private System.Windows.Forms.Button buttonClear;
    }
}