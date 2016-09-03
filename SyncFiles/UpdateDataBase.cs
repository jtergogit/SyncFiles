using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SyncFiles
{
    public partial class UpdateDataBase : Form
    {
        private DateTime expire = new DateTime(2016, 12, 1);
        public UpdateDataBase()
        {
            InitializeComponent();
            textExecuteFile.Text = @"C:\Users\wjm\Desktop\sql";
            textUpdateSite.Text = @"C:\Users\wjm\Desktop\WebSites.txt";
            if (expire < DateTime.Now)
            {
                buttonExecuteFile.Enabled = false;
                buttonUpdateSite.Enabled = false;
                buttonExecute.Enabled = false;
                MessageBox.Show("废铁一块！");
                toolStripStatusLabel1.Text = "此软件已报废。";
            }
        }

        private void buttonExecuteFile_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                    textExecuteFile.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void buttonUpdateSite_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textUpdateSite.Text = openFileDialog1.FileName;
            }
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textExecuteFile.Text))
            {
                MessageBox.Show("请选择执行文件");
                return;
            }
            if (string.IsNullOrEmpty(textUpdateSite.Text))
            {
                MessageBox.Show("请选择更新站点");
                return;
            }


            Task.Run(() =>
            {
                string siteName = "";
                try
                {
                    using (StreamReader sr = new StreamReader(textUpdateSite.Text))
                    {
                        while (!sr.EndOfStream)
                        {
                            string dirName = sr.ReadLine();
                            siteName = dirName.Substring(dirName.LastIndexOf("\\") + 1);
                            toolStripStatusLabel1.Text = "正在更新：" + siteName;


                            XmlDocument xmlConfig = new XmlDocument();
                            xmlConfig.Load(dirName.Trim() + "/Web.config");
                            XmlNode connectionNode = xmlConfig.SelectSingleNode("configuration/connectionStrings/add[@name='HidistroSqlServer']");

                            string connectionStr = connectionNode.Attributes["connectionString"].Value;

                            string[] fileName = Directory.GetFiles(textExecuteFile.Text);

                            foreach (string filePath in fileName)
                            {
                                string sqlName = Path.GetFileNameWithoutExtension(filePath);
                                try
                                {
                                    toolStripStatusLabel1.Text = "正在更新" + siteName + "：" + sqlName;
                                    ArrayList sqlList = GetSqlFile(filePath, "");
                                    ExecuteCommand(sqlList, connectionStr);
                                }
                                catch (Exception ex)
                                {
                                    WriteFile(siteName + "：" + sqlName +"---"+ ex.Message);
                                }
                            }

                        }
                    }
                    toolStripStatusLabel1.Text = "更新成功";
                    MessageBox.Show("更新成功！");
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = siteName + "：" + ex.Message;
                    MessageBox.Show(siteName + "：" + ex.Message);
                }
            });

        }

        public static ArrayList GetSqlFile(string varFileName, string dbname)
        {
            ArrayList alSql = new ArrayList();
            if (!File.Exists(varFileName))
            {
                return alSql;
            }
            StreamReader rs = new StreamReader(varFileName, System.Text.Encoding.Default);
            string commandText = "";
            string varLine = "";
            while (rs.Peek() > -1)
            {
                varLine = rs.ReadLine();
                if (varLine == "")
                {
                    continue;
                }
                if (varLine != "GO" && varLine != "go")
                {
                    commandText += varLine;
                    //commandText = commandText.Replace("@database_name=N'dbhr'", string.Format("@database_name=N'{0}'", dbname));
                    commandText += "\r\n";
                }
                else
                {
                    alSql.Add(commandText);
                    commandText = "";
                }
            }

            rs.Close();
            return alSql;
        }

        public static void ExecuteCommand(ArrayList varSqlList, string connString)
        {

            SqlConnection MyConnection = new SqlConnection(connString);
            MyConnection.Open();
            SqlTransaction varTrans = MyConnection.BeginTransaction();
            SqlCommand command = new SqlCommand();
            command.Connection = MyConnection;
            command.Transaction = varTrans;
            try
            {
                foreach (string varcommandText in varSqlList)
                {
                    command.CommandText = varcommandText;
                    command.ExecuteNonQuery();
                }
                varTrans.Commit();
            }
            catch (Exception ex)
            {
                varTrans.Rollback();
                throw ex;
            }
            finally
            {
                MyConnection.Close();
            }
        }

        private void WriteFile(string message)
        {
            StreamWriter sw = new StreamWriter(System.Environment.CurrentDirectory + "/UpdateDataBaseLog.txt", true);
            sw.WriteLine(DateTime.Now.ToString()+"-----"+message);
            sw.Close();
        }

    }
}
