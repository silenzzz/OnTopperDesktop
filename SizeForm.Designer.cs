namespace OnTopper
{
    partial class SizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SizeForm));
            this.buttonApply = new System.Windows.Forms.Button();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.labelH = new System.Windows.Forms.Label();
            this.labelW = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.groupBoxSize = new System.Windows.Forms.GroupBox();
            this.groupBoxPosition = new System.Windows.Forms.GroupBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxSize.SuspendLayout();
            this.groupBoxPosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            resources.ApplyResources(this.buttonApply, "buttonApply");
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // textBoxHeight
            // 
            resources.ApplyResources(this.textBoxHeight, "textBoxHeight");
            this.textBoxHeight.Name = "textBoxHeight";
            // 
            // labelH
            // 
            resources.ApplyResources(this.labelH, "labelH");
            this.labelH.Name = "labelH";
            // 
            // labelW
            // 
            resources.ApplyResources(this.labelW, "labelW");
            this.labelW.Name = "labelW";
            // 
            // textBoxWidth
            // 
            resources.ApplyResources(this.textBoxWidth, "textBoxWidth");
            this.textBoxWidth.Name = "textBoxWidth";
            // 
            // groupBoxSize
            // 
            resources.ApplyResources(this.groupBoxSize, "groupBoxSize");
            this.groupBoxSize.Controls.Add(this.labelH);
            this.groupBoxSize.Controls.Add(this.labelW);
            this.groupBoxSize.Controls.Add(this.textBoxWidth);
            this.groupBoxSize.Controls.Add(this.textBoxHeight);
            this.groupBoxSize.Name = "groupBoxSize";
            this.groupBoxSize.TabStop = false;
            // 
            // groupBoxPosition
            // 
            resources.ApplyResources(this.groupBoxPosition, "groupBoxPosition");
            this.groupBoxPosition.Controls.Add(this.labelX);
            this.groupBoxPosition.Controls.Add(this.labelY);
            this.groupBoxPosition.Controls.Add(this.textBoxY);
            this.groupBoxPosition.Controls.Add(this.textBoxX);
            this.groupBoxPosition.Name = "groupBoxPosition";
            this.groupBoxPosition.TabStop = false;
            // 
            // labelX
            // 
            resources.ApplyResources(this.labelX, "labelX");
            this.labelX.Name = "labelX";
            // 
            // labelY
            // 
            resources.ApplyResources(this.labelY, "labelY");
            this.labelY.Name = "labelY";
            // 
            // textBoxY
            // 
            resources.ApplyResources(this.textBoxY, "textBoxY");
            this.textBoxY.Name = "textBoxY";
            // 
            // textBoxX
            // 
            resources.ApplyResources(this.textBoxX, "textBoxX");
            this.textBoxX.Name = "textBoxX";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // SizeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxPosition);
            this.Controls.Add(this.groupBoxSize);
            this.Controls.Add(this.buttonApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SizeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.groupBoxSize.ResumeLayout(false);
            this.groupBoxSize.PerformLayout();
            this.groupBoxPosition.ResumeLayout(false);
            this.groupBoxPosition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.GroupBox groupBoxSize;
        private System.Windows.Forms.GroupBox groupBoxPosition;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Button buttonCancel;
    }
}