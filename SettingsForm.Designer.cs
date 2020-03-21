namespace OnTopper
{
    partial class SettingsForm
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
            this.checkBoxHideUninteractive = new System.Windows.Forms.CheckBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.checkBoxAutoUpdate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxHideUninteractive
            // 
            this.checkBoxHideUninteractive.AutoSize = true;
            this.checkBoxHideUninteractive.Checked = true;
            this.checkBoxHideUninteractive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHideUninteractive.Location = new System.Drawing.Point(12, 12);
            this.checkBoxHideUninteractive.Name = "checkBoxHideUninteractive";
            this.checkBoxHideUninteractive.Size = new System.Drawing.Size(121, 17);
            this.checkBoxHideUninteractive.TabIndex = 0;
            this.checkBoxHideUninteractive.Text = "Hide non interactive";
            this.checkBoxHideUninteractive.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(12, 58);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(121, 23);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // checkBoxAutoUpdate
            // 
            this.checkBoxAutoUpdate.AutoSize = true;
            this.checkBoxAutoUpdate.Enabled = false;
            this.checkBoxAutoUpdate.Location = new System.Drawing.Point(12, 35);
            this.checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            this.checkBoxAutoUpdate.Size = new System.Drawing.Size(84, 17);
            this.checkBoxAutoUpdate.TabIndex = 3;
            this.checkBoxAutoUpdate.Text = "Auto update";
            this.checkBoxAutoUpdate.UseVisualStyleBackColor = true;
            this.checkBoxAutoUpdate.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(146, 86);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxAutoUpdate);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.checkBoxHideUninteractive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxHideUninteractive;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.CheckBox checkBoxAutoUpdate;
    }
}