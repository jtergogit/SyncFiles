using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SyncFiles
{
    public partial class Form1 : Form
    {
        protected string settingPath = "Setting.config";
        public Form1()
        {
            InitializeComponent();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(settingPath);
            ProjectPath.Text = xmlDoc.SelectSingleNode("configuration/ProjectPath").InnerText;
            exportText.Text = xmlDoc.SelectSingleNode("configuration/exportText").InnerText;
            projectPaths.Text = xmlDoc.SelectSingleNode("configuration/projectPaths").InnerText;
            ignoreText.Text = xmlDoc.SelectSingleNode("configuration/ignoreText").InnerText;
        }

        /// <summary>
        /// 选择同步项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                    ProjectPath.Text = folderBrowserDialog1.SelectedPath;
                    SaveSetting("ProjectPath", ProjectPath.Text);
                }
            }
        }

        /// <summary>
        /// 选择导出站点目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                    exportText.Text = folderBrowserDialog1.SelectedPath;
                    SaveSetting("exportText", exportText.Text);
                }
            }
        }

        /// <summary>
        /// 导出站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(exportText.Text.Trim()))
            {
                MessageBox.Show("请选择导出目录");
                return;
            }
            StreamWriter sw = new StreamWriter("WebSites.txt");
            string[] directionName = Directory.GetDirectories(exportText.Text);
            foreach (string directionPath in directionName)
            {
                if (ProjectPath.Text != directionPath)
                sw.WriteLine(directionPath);
            }
            sw.Close();
            projectPaths.Text = Directory.GetCurrentDirectory() + "\\WebSites.txt";
            SaveSetting("projectPaths", projectPaths.Text);
        }   

        /// <summary>
        /// 选择同步站点文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                projectPaths.Text = openFileDialog1.FileName;
                SaveSetting("projectPaths", projectPaths.Text);
            }
        }

        /// <summary>
        /// 选择忽略文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ignoreBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ignoreText.Text = openFileDialog1.FileName;
                SaveSetting("ignoreText", ignoreText.Text);
            }
        }

        /// <summary>
        /// 保存选择的路径信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void SaveSetting(string name, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(settingPath);
            xmlDoc.SelectSingleNode("configuration/" + name).InnerText = value;
            xmlDoc.Save(settingPath);
        }

        /// <summary>
        /// 开始同步文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectPath.Text))
            {
                MessageBox.Show("请选择同步项目");
                return;
            }
            if (string.IsNullOrEmpty(projectPaths.Text))
            {
                MessageBox.Show("请选择同步位置");
                return;
            }

            Task.Run(() =>
               {
                   try
                   {
                       using (StreamReader sr = new StreamReader(projectPaths.Text))
                       {
                           while (!sr.EndOfStream)
                           {
                               string dirName = sr.ReadLine();
                               toolStripStatusLabel1.Text = "正在同步：" + dirName.Substring(dirName.LastIndexOf("\\")+1);
                               copyDirectory(ProjectPath.Text, dirName);
                           }
                       }
                       toolStripStatusLabel1.Text = "同步完成";
                   }
                   catch(Exception ex)
                   {
                       toolStripStatusLabel1.Text = ex.Message;
                       MessageBox.Show(ex.Message);
                   }
               });
        }

        /// <summary>
        /// 检查忽略文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="ignoreFile"></param>
        /// <returns></returns>
        private bool IgnoreFiles(string fileName)
        {
            using (StreamReader sr = new StreamReader(ignoreText.Text))
            {
                while (!sr.EndOfStream)
                {
                    if (Path.Equals(fileName, sr.ReadLine()))
                    {
                        return false;
                    }
                }
                sr.Close();
            }
            return true;
        }

        /// <summary>
        /// 遍历递归文件
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="destDirectory"></param>
         public void copyDirectory(string sourceDirectory, string destDirectory)
        {
            if (IgnoreFiles(sourceDirectory) && sourceDirectory != destDirectory)
            {
                //判断源目录和目标目录是否存在，如果不存在，则创建一个目录
                if (!Directory.Exists(sourceDirectory))
                {
                    Directory.CreateDirectory(sourceDirectory);
                }
                if (!Directory.Exists(destDirectory))
                {
                    Directory.CreateDirectory(destDirectory);
                }
                //拷贝文件
                copyFile(sourceDirectory, destDirectory);

                //拷贝子目录       
                //获取所有子目录名称
                string[] directionName = Directory.GetDirectories(sourceDirectory);

                foreach (string directionPath in directionName)
                {
                    //根据每个子目录名称生成对应的目标子目录名称
                    string directionPathTemp = destDirectory + "\\" + directionPath.Substring(sourceDirectory.Length + 1);

                    //递归下去
                    copyDirectory(directionPath, directionPathTemp);
                }
            } 
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="destDirectory"></param>
        public void copyFile(string sourceDirectory, string destDirectory)
        {
            //获取所有文件名称
            string[] fileName = Directory.GetFiles(sourceDirectory);
           
            foreach (string filePath in fileName)
            {
                if (IgnoreFiles(filePath))
                {
                    //根据每个文件名称生成对应的目标文件名称
                    string filePathTemp = destDirectory + "\\" +  filePath.Substring(sourceDirectory.Length + 1);;

                    //若不存在，直接复制文件；若存在，覆盖复制
                    if (File.Exists(filePathTemp))
                    {
                        File.Copy(filePath, filePathTemp, true);
                    }
                    else
                    {
                        File.Copy(filePath, filePathTemp);
                    }
                }
            }
        }
 
    }
}
