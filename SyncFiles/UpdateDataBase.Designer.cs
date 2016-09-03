namespace SyncFiles
{
    partial class UpdateDataBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDataBase));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonExecuteFile = new System.Windows.Forms.Button();
            this.textExecuteFile = new System.Windows.Forms.TextBox();
            this.labelExecuteFile = new System.Windows.Forms.Label();
            this.labelUpdateSite = new System.Windows.Forms.Label();
            this.textUpdateSite = new System.Windows.Forms.TextBox();
            this.buttonUpdateSite = new System.Windows.Forms.Button();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExecuteFile
            // 
            this.buttonExecuteFile.Location = new System.Drawing.Point(359, 30);
            this.buttonExecuteFile.Name = "buttonExecuteFile";
            this.buttonExecuteFile.Size = new System.Drawing.Size(75, 23);
            this.buttonExecuteFile.TabIndex = 12;
            this.buttonExecuteFile.Text = "选择文件";
            this.buttonExecuteFile.UseVisualStyleBackColor = true;
            this.buttonExecuteFile.Click += new System.EventHandler(this.buttonExecuteFile_Click);
            // 
            // textExecuteFile
            // 
            this.textExecuteFile.Location = new System.Drawing.Point(83, 32);
            this.textExecuteFile.Name = "textExecuteFile";
            this.textExecuteFile.Size = new System.Drawing.Size(270, 21);
            this.textExecuteFile.TabIndex = 11;
            // 
            // labelExecuteFile
            // 
            this.labelExecuteFile.AutoSize = true;
            this.labelExecuteFile.Location = new System.Drawing.Point(12, 41);
            this.labelExecuteFile.Name = "labelExecuteFile";
            this.labelExecuteFile.Size = new System.Drawing.Size(65, 12);
            this.labelExecuteFile.TabIndex = 14;
            this.labelExecuteFile.Text = "执行文件：";
            // 
            // labelUpdateSite
            // 
            this.labelUpdateSite.AutoSize = true;
            this.labelUpdateSite.Location = new System.Drawing.Point(12, 104);
            this.labelUpdateSite.Name = "labelUpdateSite";
            this.labelUpdateSite.Size = new System.Drawing.Size(65, 12);
            this.labelUpdateSite.TabIndex = 15;
            this.labelUpdateSite.Text = "更新站点：";
            // 
            // textUpdateSite
            // 
            this.textUpdateSite.Location = new System.Drawing.Point(83, 95);
            this.textUpdateSite.Name = "textUpdateSite";
            this.textUpdateSite.Size = new System.Drawing.Size(270, 21);
            this.textUpdateSite.TabIndex = 16;
            // 
            // buttonUpdateSite
            // 
            this.buttonUpdateSite.Location = new System.Drawing.Point(359, 93);
            this.buttonUpdateSite.Name = "buttonUpdateSite";
            this.buttonUpdateSite.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateSite.TabIndex = 17;
            this.buttonUpdateSite.Text = "选择文件";
            this.buttonUpdateSite.UseVisualStyleBackColor = true;
            this.buttonUpdateSite.Click += new System.EventHandler(this.buttonUpdateSite_Click);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(359, 144);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(75, 23);
            this.buttonExecute.TabIndex = 18;
            this.buttonExecute.Text = "执行";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
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
            // UpdateDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 192);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.buttonUpdateSite);
            this.Controls.Add(this.textUpdateSite);
            this.Controls.Add(this.labelUpdateSite);
            this.Controls.Add(this.labelExecuteFile);
            this.Controls.Add(this.buttonExecuteFile);
            this.Controls.Add(this.textExecuteFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateDataBase";
            this.Text = "更新数据库（注：本软件属个人所有，不得用于商业用途，违者将负法律责任。作者：温金茂）";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonExecuteFile;
        private System.Windows.Forms.TextBox textExecuteFile;
        private System.Windows.Forms.Label labelExecuteFile;
        private System.Windows.Forms.Label labelUpdateSite;
        private System.Windows.Forms.TextBox textUpdateSite;
        private System.Windows.Forms.Button buttonUpdateSite;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}