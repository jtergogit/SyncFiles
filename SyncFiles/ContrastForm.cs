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
    public partial class ContrastForm : Form
    {
        public ContrastForm()
        {
            InitializeComponent();
            textLacaConfig.Text = @"E:\abaizx\fx";
            textWebConfig.Text = @"C:\Users\wjm\Desktop\WebSites.txt";
        }

        private void buttonLacaConfig_Click(object sender, EventArgs e)
        {
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    textLacaConfig.Text = openFileDialog1.FileName;
            //}
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                    textLacaConfig.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void buttonWebConfig_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textWebConfig.Text = openFileDialog1.FileName;
            }
            //if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            //    {
            //        textWebConfig.Text = folderBrowserDialog1.SelectedPath;
            //    }
            //}
        }

        private void buttonContras_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textLacaConfig.Text))
            {
                MessageBox.Show("请选择本地配置");
                return;
            }
            if (string.IsNullOrEmpty(textWebConfig.Text))
            {
                MessageBox.Show("请选择站点配置");
                return;
            }
            string locaPath = textLacaConfig.Text + "/config/SiteSettings.config";

            XmlDocument xmlLoca = new XmlDocument();
            xmlLoca.Load(locaPath);
            Task.Run(() =>
          {
              try
              {
                  using (StreamReader sr = new StreamReader(textWebConfig.Text))
                  {
                      while (!sr.EndOfStream)
                      {
                          string dirName = sr.ReadLine();
                          toolStripStatusLabel1.Text = "正在对比：" + dirName.Substring(dirName.LastIndexOf("\\") + 1);
                          string webPath = dirName + "/config/SiteSettings.config";

                          XmlDocument xmlWeb = new XmlDocument();
                          xmlWeb.Load(webPath);

                          XmlNodeList listLoca = xmlLoca.SelectSingleNode("Settings").ChildNodes;

                          XmlNodeList listWeb = xmlWeb.SelectSingleNode("Settings").ChildNodes;


                          string result = "";
                          foreach (XmlNode nodeLoca in listLoca)
                          {
                              bool compare = true;
                              foreach (XmlNode nodeWeb in listWeb)
                              {
                                  if (nodeLoca.Name == nodeWeb.Name)
                                  {
                                      compare = false;
                                      break;
                                  }
                              }
                              if (compare)
                              {
                                  if (nodeLoca.Name != "#comment")
                                      result += nodeLoca.Name + ",";
                              }
                          }

                          //WriteFile(result);
                          if (string.IsNullOrEmpty(result))
                          {
                              //MessageBox.Show("完全匹配！");
                          }
                          else
                          {
                              //MessageBox.Show("结果：" + result);




                              foreach (string item in result.Split(','))
                              {
                                  if (!string.IsNullOrEmpty(item))
                                  {
                                      XmlNode root = xmlWeb.CreateElement(item);
                                      string text = xmlLoca.SelectSingleNode("Settings/" + item).InnerText;
                                      int tnum = 0;
                                      if (int.TryParse(text, out tnum))
                                      {
                                          root.InnerText = "0";
                                      }
                                      else if (text.ToLower() == "false" || text.ToLower() == "true")
                                      {
                                          root.InnerText = "false";
                                      }
                                      else
                                      {
                                          root.InnerText = "";
                                      }
                                      xmlWeb.SelectSingleNode("Settings").AppendChild(root);
                                  }
                              }
                              xmlWeb.Save(webPath);

                          }
                      }
                  }
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
              toolStripStatusLabel1.Text = "匹配完成";
          });
            MessageBox.Show("匹配成功！");

        }

        private void WriteFile(string message)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\Administrator\Desktop\CompareResult.txt", false);
            foreach (string item in message.Split(','))
            {
                if(!string.IsNullOrEmpty(item))
                    sw.WriteLine(item);
            }
            sw.Close();
        }
    }
}
