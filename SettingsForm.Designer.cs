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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.checkBoxHideUninteractive = new System.Windows.Forms.CheckBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.checkBoxAutoUpdate = new System.Windows.Forms.CheckBox();
            this.buttonAutorun = new System.Windows.Forms.Button();
            this.groupBoxProcesses = new System.Windows.Forms.GroupBox();
            this.checkBoxShowWindowTitles = new System.Windows.Forms.CheckBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBoxStartup = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoHide = new System.Windows.Forms.CheckBox();
            this.buttonCheckUpdates = new System.Windows.Forms.Button();
            this.groupBoxProcesses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.groupBoxStartup.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxHideUninteractive
            // 
            resources.ApplyResources(this.checkBoxHideUninteractive, "checkBoxHideUninteractive");
            this.checkBoxHideUninteractive.Checked = true;
            this.checkBoxHideUninteractive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHideUninteractive.Name = "checkBoxHideUninteractive";
            this.checkBoxHideUninteractive.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            resources.ApplyResources(this.buttonApply, "buttonApply");
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // checkBoxAutoUpdate
            // 
            resources.ApplyResources(this.checkBoxAutoUpdate, "checkBoxAutoUpdate");
            this.checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            this.checkBoxAutoUpdate.UseVisualStyleBackColor = true;
            this.checkBoxAutoUpdate.CheckedChanged += new System.EventHandler(this.CheckBoxAutoUpdate_CheckedChanged);
            // 
            // buttonAutorun
            // 
            resources.ApplyResources(this.buttonAutorun, "buttonAutorun");
            this.buttonAutorun.Name = "buttonAutorun";
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
            resources.ApplyResources(this.groupBoxProcesses, "groupBoxProcesses");
            this.groupBoxProcesses.Name = "groupBoxProcesses";
            this.groupBoxProcesses.TabStop = false;
            // 
            // checkBoxShowWindowTitles
            // 
            resources.ApplyResources(this.checkBoxShowWindowTitles, "checkBoxShowWindowTitles");
            this.checkBoxShowWindowTitles.Name = "checkBoxShowWindowTitles";
            this.checkBoxShowWindowTitles.UseVisualStyleBackColor = true;
            // 
            // labelInterval
            // 
            resources.ApplyResources(this.labelInterval, "labelInterval");
            this.labelInterval.Name = "labelInterval";
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.numericUpDownInterval, "numericUpDownInterval");
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
            this.numericUpDownInterval.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // groupBoxStartup
            // 
            this.groupBoxStartup.Controls.Add(this.checkBoxAutoHide);
            this.groupBoxStartup.Controls.Add(this.buttonAutorun);
            resources.ApplyResources(this.groupBoxStartup, "groupBoxStartup");
            this.groupBoxStartup.Name = "groupBoxStartup";
            this.groupBoxStartup.TabStop = false;
            // 
            // checkBoxAutoHide
            // 
            resources.ApplyResources(this.checkBoxAutoHide, "checkBoxAutoHide");
            this.checkBoxAutoHide.Name = "checkBoxAutoHide";
            this.checkBoxAutoHide.UseVisualStyleBackColor = true;
            // 
            // buttonCheckUpdates
            // 
            resources.ApplyResources(this.buttonCheckUpdates, "buttonCheckUpdates");
            this.buttonCheckUpdates.Name = "buttonCheckUpdates";
            this.buttonCheckUpdates.UseVisualStyleBackColor = true;
            this.buttonCheckUpdates.Click += new System.EventHandler(this.ButtonCheckUpdates_Click);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.buttonCheckUpdates);
            this.Controls.Add(this.groupBoxProcesses);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBoxStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
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
        private System.Windows.Forms.Button buttonCheckUpdates;
    }
}