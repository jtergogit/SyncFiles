namespace SyncFiles
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ProjectPath = new System.Windows.Forms.TextBox();
            this.SelectFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.MoveFile = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.projectPaths = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.exportText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.exportBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ignoreText = new System.Windows.Forms.TextBox();
            this.ignoreBtn = new System.Windows.Forms.Button();
            this.exportSelect = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProjectPath
            // 
            this.ProjectPath.Location = new System.Drawing.Point(132, 10);
            this.ProjectPath.Name = "ProjectPath";
            this.ProjectPath.Size = new System.Drawing.Size(261, 21);
            this.ProjectPath.TabIndex = 0;
            // 
            // SelectFolder
            // 
            this.SelectFolder.Location = new System.Drawing.Point(393, 9);
            this.SelectFolder.Name = "SelectFolder";
            this.SelectFolder.Size = new System.Drawing.Size(75, 23);
            this.SelectFolder.TabIndex = 1;
            this.SelectFolder.Text = "选择文件夹";
            this.SelectFolder.UseVisualStyleBackColor = true;
            this.SelectFolder.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "同步的项目：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "同步位置：";
            // 
            // MoveFile
            // 
            this.MoveFile.Location = new System.Drawing.Point(393, 178);
            this.MoveFile.Name = "MoveFile";
            this.MoveFile.Size = new System.Drawing.Size(75, 23);
            this.MoveFile.TabIndex = 6;
            this.MoveFile.Text = "开始";
            this.MoveFile.UseVisualStyleBackColor = true;
            this.MoveFile.Click += new System.EventHandler(this.MoveFile_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 215);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(501, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel1.Text = "正在准备。。。";
            // 
            // projectPaths
            // 
            this.projectPaths.Location = new System.Drawing.Point(132, 90);
            this.projectPaths.Name = "projectPaths";
            this.projectPaths.Size = new System.Drawing.Size(261, 21);
            this.projectPaths.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "选择文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // exportText
            // 
            this.exportText.Location = new System.Drawing.Point(132, 51);
            this.exportText.Name = "exportText";
            this.exportText.Size = new System.Drawing.Size(195, 21);
            this.exportText.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "导出站点：";
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(414, 51);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(75, 23);
            this.exportBtn.TabIndex = 12;
            this.exportBtn.Text = "导出";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "忽略文件：";
            // 
            // ignoreText
            // 
            this.ignoreText.Location = new System.Drawing.Point(132, 128);
            this.ignoreText.Name = "ignoreText";
            this.ignoreText.Size = new System.Drawing.Size(261, 21);
            this.ignoreText.TabIndex = 14;
            // 
            // ignoreBtn
            // 
            this.ignoreBtn.Location = new System.Drawing.Point(393, 126);
            this.ignoreBtn.Name = "ignoreBtn";
            this.ignoreBtn.Size = new System.Drawing.Size(75, 23);
            this.ignoreBtn.TabIndex = 15;
            this.ignoreBtn.Text = "选择文件";
            this.ignoreBtn.UseVisualStyleBackColor = true;
            this.ignoreBtn.Click += new System.EventHandler(this.ignoreBtn_Click);
            // 
            // exportSelect
            // 
            this.exportSelect.Location = new System.Drawing.Point(333, 51);
            this.exportSelect.Name = "exportSelect";
            this.exportSelect.Size = new System.Drawing.Size(75, 23);
            this.exportSelect.TabIndex = 16;
            this.exportSelect.Text = "选择目录";
            this.exportSelect.UseVisualStyleBackColor = true;
            this.exportSelect.Click += new System.EventHandler(this.exportSelect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 237);
            this.Controls.Add(this.exportSelect);
            this.Controls.Add(this.ignoreBtn);
            this.Controls.Add(this.ignoreText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.exportText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.projectPaths);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MoveFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectFolder);
            this.Controls.Add(this.ProjectPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "同步文件 （注：本软件属个人所有，不得用于商业用途，违者将负法律责任。作者：温金茂）";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProjectPath;
        private System.Windows.Forms.Button SelectFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button MoveFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox projectPaths;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox exportText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ignoreText;
        private System.Windows.Forms.Button ignoreBtn;
        private System.Windows.Forms.Button exportSelect;
    }
}

