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
            textLacaConfig.Text = @"C:\Users\Administrator\Desktop\LSiteSettings.config";
            textWebConfig.Text = @"C:\Users\Administrator\Desktop\SiteSettings.config";
        }

        private void buttonLacaConfig_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textLacaConfig.Text = openFileDialog1.FileName;
            }
        }

        private void buttonWebConfig_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textWebConfig.Text = openFileDialog1.FileName;
            }
        }

        private void buttonContras_Click(object sender, EventArgs e)
        {
            try
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

                XmlDocument xmlLoca = new XmlDocument();
                xmlLoca.Load(textLacaConfig.Text);

                XmlDocument xmlWeb = new XmlDocument();
                xmlWeb.Load(textWebConfig.Text);

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

                WriteFile(result);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("完全匹配！");
                }
                else
                {
                    MessageBox.Show("结果：" + result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
