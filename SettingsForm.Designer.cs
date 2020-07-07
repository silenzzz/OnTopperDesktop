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
            this.buttonAutorun = new System.Windows.Forms.Button();
            this.groupBoxProcesses = new System.Windows.Forms.GroupBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBoxStartup = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoHide = new System.Windows.Forms.CheckBox();
            this.checkBoxShowWindowTitles = new System.Windows.Forms.CheckBox();
            this.groupBoxProcesses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.groupBoxStartup.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxHideUninteractive
            // 
            this.checkBoxHideUninteractive.AutoSize = true;
            this.checkBoxHideUninteractive.Checked = true;
            this.checkBoxHideUninteractive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHideUninteractive.Location = new System.Drawing.Point(6, 19);
            this.checkBoxHideUninteractive.Name = "checkBoxHideUninteractive";
            this.checkBoxHideUninteractive.Size = new System.Drawing.Size(121, 17);
            this.checkBoxHideUninteractive.TabIndex = 0;
            this.checkBoxHideUninteractive.Text = "Hide non interactive";
            this.checkBoxHideUninteractive.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(164, 107);
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
            this.checkBoxAutoUpdate.Location = new System.Drawing.Point(6, 56);
            this.checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            this.checkBoxAutoUpdate.Size = new System.Drawing.Size(84, 17);
            this.checkBoxAutoUpdate.TabIndex = 3;
            this.checkBoxAutoUpdate.Text = "Auto update";
            this.checkBoxAutoUpdate.UseVisualStyleBackColor = true;
            this.checkBoxAutoUpdate.CheckedChanged += new System.EventHandler(this.CheckBoxAutoUpdate_CheckedChanged);
            // 
            // buttonAutorun
            // 
            this.buttonAutorun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAutorun.Location = new System.Drawing.Point(6, 19);
            this.buttonAutorun.Name = "buttonAutorun";
            this.buttonAutorun.Size = new System.Drawing.Size(111, 40);
            this.buttonAutorun.TabIndex = 4;
            this.buttonAutorun.Text = "Enable on startup";
            this.buttonAutorun.UseVisualStyleBackColor = true;
            this.buttonAutorun.Click += new System.EventHandler(this.ButtonAutorunOff_Click);
            // 
            // groupBoxProcesses
            // 
            this.groupBoxProcesses.Controls.Add(this.checkBoxShowWindowTitles);
            this.groupBoxProcesses.Controls.Add(this.labelInterval);
            this.groupBoxProcesses.Controls.Add(this.numericUpDownInterval);
            this.groupBoxProcesses.Controls.Add(this.checkBoxAutoUpdate);
            this.groupBoxProcesses.Controls.Add(this.checkBoxHideUninteractive);
            this.groupBoxProcesses.Location = new System.Drawing.Point(6, 12);
            this.groupBoxProcesses.Name = "groupBoxProcesses";
            this.groupBoxProcesses.Size = new System.Drawing.Size(152, 118);
            this.groupBoxProcesses.TabIndex = 5;
            this.groupBoxProcesses.TabStop = false;
            this.groupBoxProcesses.Text = "Processes";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(6, 76);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(79, 13);
            this.labelInterval.TabIndex = 5;
            this.labelInterval.Text = "Update interval";
            this.labelInterval.Visible = false;
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownInterval.Location = new System.Drawing.Point(6, 92);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDownInterval.Size = new System.Drawing.Size(79, 20);
            this.numericUpDownInterval.TabIndex = 4;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownInterval.Visible = false;
            // 
            // groupBoxStartup
            // 
            this.groupBoxStartup.Controls.Add(this.checkBoxAutoHide);
            this.groupBoxStartup.Controls.Add(this.buttonAutorun);
            this.groupBoxStartup.Location = new System.Drawing.Point(164, 12);
            this.groupBoxStartup.Name = "groupBoxStartup";
            this.groupBoxStartup.Size = new System.Drawing.Size(121, 89);
            this.groupBoxStartup.TabIndex = 6;
            this.groupBoxStartup.TabStop = false;
            this.groupBoxStartup.Text = "Startup";
            // 
            // checkBoxAutoHide
            // 
            this.checkBoxAutoHide.AutoSize = true;
            this.checkBoxAutoHide.Location = new System.Drawing.Point(13, 65);
            this.checkBoxAutoHide.Name = "checkBoxAutoHide";
            this.checkBoxAutoHide.Size = new System.Drawing.Size(96, 17);
            this.checkBoxAutoHide.TabIndex = 6;
            this.checkBoxAutoHide.Text = "Start minimized";
            this.checkBoxAutoHide.UseVisualStyleBackColor = true;
            this.checkBoxAutoHide.Visible = false;
            this.checkBoxAutoHide.CheckedChanged += new System.EventHandler(this.CheckBoxAutoHide_CheckedChanged);
            // 
            // checkBoxShowWindowTitles
            // 
            this.checkBoxShowWindowTitles.AutoSize = true;
            this.checkBoxShowWindowTitles.Location = new System.Drawing.Point(6, 37);
            this.checkBoxShowWindowTitles.Name = "checkBoxShowWindowTitles";
            this.checkBoxShowWindowTitles.Size = new System.Drawing.Size(116, 17);
            this.checkBoxShowWindowTitles.TabIndex = 6;
            this.checkBoxShowWindowTitles.Text = "Show window titles";
            this.checkBoxShowWindowTitles.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(289, 135);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxProcesses);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBoxStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBoxProcesses.ResumeLayout(false);
            this.groupBoxProcesses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.groupBoxStartup.ResumeLayout(false);
            this.groupBoxStartup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxHideUninteractive;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.CheckBox checkBoxAutoUpdate;
        private System.Windows.Forms.Button buttonAutorun;
        private System.Windows.Forms.GroupBox groupBoxProcesses;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.GroupBox groupBoxStartup;
        private System.Windows.Forms.CheckBox checkBoxAutoHide;
        private System.Windows.Forms.CheckBox checkBoxShowWindowTitles;
    }
}