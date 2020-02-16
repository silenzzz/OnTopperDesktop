namespace OnTopper
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listBoxProcesses = new System.Windows.Forms.ListBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSetTop = new System.Windows.Forms.Button();
            this.buttonUnsetTop = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonThisOnTop = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.labelSelectProcess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxProcesses
            // 
            this.listBoxProcesses.FormattingEnabled = true;
            this.listBoxProcesses.Location = new System.Drawing.Point(12, 38);
            this.listBoxProcesses.Name = "listBoxProcesses";
            this.listBoxProcesses.Size = new System.Drawing.Size(161, 134);
            this.listBoxProcesses.TabIndex = 0;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(179, 61);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(94, 23);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // buttonSetTop
            // 
            this.buttonSetTop.Location = new System.Drawing.Point(179, 120);
            this.buttonSetTop.Name = "buttonSetTop";
            this.buttonSetTop.Size = new System.Drawing.Size(94, 23);
            this.buttonSetTop.TabIndex = 2;
            this.buttonSetTop.Text = "Set top";
            this.buttonSetTop.UseVisualStyleBackColor = true;
            this.buttonSetTop.Click += new System.EventHandler(this.ButtonSetTop_Click);
            // 
            // buttonUnsetTop
            // 
            this.buttonUnsetTop.Location = new System.Drawing.Point(179, 149);
            this.buttonUnsetTop.Name = "buttonUnsetTop";
            this.buttonUnsetTop.Size = new System.Drawing.Size(94, 23);
            this.buttonUnsetTop.TabIndex = 3;
            this.buttonUnsetTop.Text = "Unset top";
            this.buttonUnsetTop.UseVisualStyleBackColor = true;
            this.buttonUnsetTop.Click += new System.EventHandler(this.ButtonUnsetTop_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(12, 12);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(105, 20);
            this.textBoxSearch.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(123, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(50, 20);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // buttonThisOnTop
            // 
            this.buttonThisOnTop.Location = new System.Drawing.Point(179, 90);
            this.buttonThisOnTop.Name = "buttonThisOnTop";
            this.buttonThisOnTop.Size = new System.Drawing.Size(94, 23);
            this.buttonThisOnTop.TabIndex = 6;
            this.buttonThisOnTop.Text = "Set this";
            this.buttonThisOnTop.UseVisualStyleBackColor = true;
            this.buttonThisOnTop.Click += new System.EventHandler(this.ButtonThisOnTop_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAbout.Location = new System.Drawing.Point(253, 11);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(20, 20);
            this.buttonAbout.TabIndex = 7;
            this.buttonAbout.Text = "I";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
            // 
            // labelSelectProcess
            // 
            this.labelSelectProcess.AutoSize = true;
            this.labelSelectProcess.Location = new System.Drawing.Point(178, 38);
            this.labelSelectProcess.Name = "labelSelectProcess";
            this.labelSelectProcess.Size = new System.Drawing.Size(96, 13);
            this.labelSelectProcess.TabIndex = 8;
            this.labelSelectProcess.Text = "Select process first";
            this.labelSelectProcess.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 184);
            this.Controls.Add(this.labelSelectProcess);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonThisOnTop);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonUnsetTop);
            this.Controls.Add(this.buttonSetTop);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.listBoxProcesses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnTopper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxProcesses;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSetTop;
        private System.Windows.Forms.Button buttonUnsetTop;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonThisOnTop;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Label labelSelectProcess;
    }
}

