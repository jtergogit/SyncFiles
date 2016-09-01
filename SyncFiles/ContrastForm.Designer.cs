namespace SyncFiles
{
    partial class ContrastForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContrastForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonLacaConfig = new System.Windows.Forms.Button();
            this.textLacaConfig = new System.Windows.Forms.TextBox();
            this.labelLacaConfig = new System.Windows.Forms.Label();
            this.labelWebConfig = new System.Windows.Forms.Label();
            this.textWebConfig = new System.Windows.Forms.TextBox();
            this.buttonWebConfig = new System.Windows.Forms.Button();
            this.buttonContras = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLacaConfig
            // 
            this.buttonLacaConfig.Location = new System.Drawing.Point(359, 30);
            this.buttonLacaConfig.Name = "buttonLacaConfig";
            this.buttonLacaConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonLacaConfig.TabIndex = 12;
            this.buttonLacaConfig.Text = "选择文件";
            this.buttonLacaConfig.UseVisualStyleBackColor = true;
            this.buttonLacaConfig.Click += new System.EventHandler(this.buttonLacaConfig_Click);
            // 
            // textLacaConfig
            // 
            this.textLacaConfig.Location = new System.Drawing.Point(83, 32);
            this.textLacaConfig.Name = "textLacaConfig";
            this.textLacaConfig.Size = new System.Drawing.Size(270, 21);
            this.textLacaConfig.TabIndex = 11;
            // 
            // labelLacaConfig
            // 
            this.labelLacaConfig.AutoSize = true;
            this.labelLacaConfig.Location = new System.Drawing.Point(12, 41);
            this.labelLacaConfig.Name = "labelLacaConfig";
            this.labelLacaConfig.Size = new System.Drawing.Size(65, 12);
            this.labelLacaConfig.TabIndex = 14;
            this.labelLacaConfig.Text = "本地配置：";
            // 
            // labelWebConfig
            // 
            this.labelWebConfig.AutoSize = true;
            this.labelWebConfig.Location = new System.Drawing.Point(12, 104);
            this.labelWebConfig.Name = "labelWebConfig";
            this.labelWebConfig.Size = new System.Drawing.Size(65, 12);
            this.labelWebConfig.TabIndex = 15;
            this.labelWebConfig.Text = "站点配置：";
            // 
            // textWebConfig
            // 
            this.textWebConfig.Location = new System.Drawing.Point(83, 95);
            this.textWebConfig.Name = "textWebConfig";
            this.textWebConfig.Size = new System.Drawing.Size(270, 21);
            this.textWebConfig.TabIndex = 16;
            // 
            // buttonWebConfig
            // 
            this.buttonWebConfig.Location = new System.Drawing.Point(359, 93);
            this.buttonWebConfig.Name = "buttonWebConfig";
            this.buttonWebConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonWebConfig.TabIndex = 17;
            this.buttonWebConfig.Text = "选择文件";
            this.buttonWebConfig.UseVisualStyleBackColor = true;
            this.buttonWebConfig.Click += new System.EventHandler(this.buttonWebConfig_Click);
            // 
            // buttonContras
            // 
            this.buttonContras.Location = new System.Drawing.Point(359, 144);
            this.buttonContras.Name = "buttonContras";
            this.buttonContras.Size = new System.Drawing.Size(75, 23);
            this.buttonContras.TabIndex = 18;
            this.buttonContras.Text = "对比";
            this.buttonContras.UseVisualStyleBackColor = true;
            this.buttonContras.Click += new System.EventHandler(this.buttonContras_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 170);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(444, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel1.Text = "正在准备。。。";
            // 
            // ContrastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 192);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonContras);
            this.Controls.Add(this.buttonWebConfig);
            this.Controls.Add(this.textWebConfig);
            this.Controls.Add(this.labelWebConfig);
            this.Controls.Add(this.labelLacaConfig);
            this.Controls.Add(this.buttonLacaConfig);
            this.Controls.Add(this.textLacaConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContrastForm";
            this.Text = "配置对比（注：本软件属个人所有，不得用于商业用途，违者将负法律责任。作者：温金茂）";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonLacaConfig;
        private System.Windows.Forms.TextBox textLacaConfig;
        private System.Windows.Forms.Label labelLacaConfig;
        private System.Windows.Forms.Label labelWebConfig;
        private System.Windows.Forms.TextBox textWebConfig;
        private System.Windows.Forms.Button buttonWebConfig;
        private System.Windows.Forms.Button buttonContras;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}