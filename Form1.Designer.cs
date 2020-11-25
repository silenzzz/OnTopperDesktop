namespace OnTopper
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxProcesses = new System.Windows.Forms.ListBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSetTop = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonThisOnTop = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonTransparency = new System.Windows.Forms.Button();
            this.buttonProperties = new System.Windows.Forms.Button();
            this.buttonLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxProcesses
            // 
            resources.ApplyResources(this.listBoxProcesses, "listBoxProcesses");
            this.listBoxProcesses.Name = "listBoxProcesses";
            this.listBoxProcesses.Sorted = true;
            this.listBoxProcesses.Click += new System.EventHandler(this.ListBoxProcesses_Click);
            this.listBoxProcesses.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxProcesses_MouseDoubleClick);
            // 
            // buttonUpdate
            // 
            resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // buttonSetTop
            // 
            resources.ApplyResources(this.buttonSetTop, "buttonSetTop");
            this.buttonSetTop.Name = "buttonSetTop";
            this.buttonSetTop.UseVisualStyleBackColor = true;
            this.buttonSetTop.Click += new System.EventHandler(this.ButtonSetTop_Click);
            // 
            // textBoxSearch
            // 
            resources.ApplyResources(this.textBoxSearch, "textBoxSearch");
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            // 
            // buttonThisOnTop
            // 
            resources.ApplyResources(this.buttonThisOnTop, "buttonThisOnTop");
            this.buttonThisOnTop.Name = "buttonThisOnTop";
            this.buttonThisOnTop.UseVisualStyleBackColor = true;
            this.buttonThisOnTop.Click += new System.EventHandler(this.ButtonThisOnTop_Click);
            // 
            // buttonAbout
            // 
            resources.ApplyResources(this.buttonAbout, "buttonAbout");
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
            // 
            // buttonSettings
            // 
            resources.ApplyResources(this.buttonSettings, "buttonSettings");
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // buttonTransparency
            // 
            resources.ApplyResources(this.buttonTransparency, "buttonTransparency");
            this.buttonTransparency.Name = "buttonTransparency";
            this.buttonTransparency.UseVisualStyleBackColor = true;
            this.buttonTransparency.Click += new System.EventHandler(this.ButtonTransparency_Click);
            // 
            // buttonProperties
            // 
            resources.ApplyResources(this.buttonProperties, "buttonProperties");
            this.buttonProperties.Name = "buttonProperties";
            this.buttonProperties.UseVisualStyleBackColor = true;
            this.buttonProperties.Click += new System.EventHandler(this.ButtonProperties_Click);
            // 
            // buttonLog
            // 
            resources.ApplyResources(this.buttonLog, "buttonLog");
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.ButtonLog_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.buttonProperties);
            this.Controls.Add(this.buttonTransparency);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonThisOnTop);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSetTop);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.listBoxProcesses);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxProcesses;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSetTop;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonThisOnTop;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonTransparency;
        private System.Windows.Forms.Button buttonProperties;
        private System.Windows.Forms.Button buttonLog;
    }
}

