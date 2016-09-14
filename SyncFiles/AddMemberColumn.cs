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
    public partial class AddMemberColumn : Form
    {
        private DateTime expire = new DateTime(2016, 12, 1);
        public AddMemberColumn()
        {
            InitializeComponent();
            textLacaConfig.Text = @"E:\abaizx\fx";
            textWebConfig.Text = @"C:\Users\wjm\Desktop\WebSites.txt";

            //textLacaConfig.Text = @"C:\Users\Administrator\Desktop\a";
            //textWebConfig.Text = @"C:\Users\Administrator\Desktop\mc.txt";

            if (expire < DateTime.Now)
            {
                buttonLacaConfig.Enabled = false;
                buttonWebConfig.Enabled = false;
                buttonContras.Enabled = false;
                MessageBox.Show("废铁一块！");
                toolStripStatusLabel1.Text = "此软件已报废。";
            }
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
            string locaPath = textLacaConfig.Text + "/config/MemberMenu.xml";

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
                            string webPath = dirName + "/config/MemberMenu.xml";
                            if (!File.Exists(webPath))
                            {
                                File.Copy(locaPath, webPath);
                                continue;
                            }
                            XmlDocument xmlWeb = new XmlDocument();
                            xmlWeb.Load(webPath);

                            XmlNodeList listLoca = xmlLoca.SelectSingleNode("List").ChildNodes;

                            XmlNodeList listWeb = xmlWeb.SelectSingleNode("List").ChildNodes;


                            List<string> result = new List<string>();
                            
                            for (int i = 0; i < listLoca.Count; i++)
                            {
                                XmlNodeList menus = listLoca[i].ChildNodes;
                                foreach (XmlNode menu in menus)
                                {
                                    bool compare = true;
                                    for (int y = 0; y < listWeb.Count; y++)
                                    {
                                        XmlNodeList webxml = listWeb[y].ChildNodes;
                                        foreach (XmlNode nodeWeb in webxml)
                                        {
                                            if (menu.Attributes["name"].Value == nodeWeb.Attributes["name"].Value)
                                            {
                                                compare = false;
                                                break;
                                            }
                                        }
                                    }
                                    if (compare)
                                    {
                                        if (menu.Attributes["name"].Value != "#comment")
                                        {
                                            result.Add(i + menu.Attributes["name"].Value);
                                        }
                                    }
                                }
                            }

                            //WriteFile(result);
                            if (result.Count == 0)
                            {
                                //MessageBox.Show("完全匹配！");
                            }
                            else
                            {
                                for (int s = 0; s < result.Count; s++)
                                {
                                    string ix = result[s].Substring(0, 1);
                                    string addname = result[s].Substring(1);
                                    XmlNode LocaRoot = xmlLoca.SelectSingleNode("List/Item[" + ix + "]/Menu[@name='" + addname + "']");
                                    XmlElement root = xmlWeb.CreateElement(LocaRoot.Name);
                                    root.SetAttribute("name", LocaRoot.Attributes["name"].Value);
                                    root.SetAttribute("display", "False");
                                    root.SetAttribute("href", LocaRoot.Attributes["href"].Value);
                                    root.SetAttribute("img", LocaRoot.Attributes["img"].Value);
                                    root.InnerText = LocaRoot.InnerText;
                                    xmlWeb.SelectSingleNode("List/Item[" + ix + "]").AppendChild(root);
                                }
                                xmlWeb.Save(webPath);
                            }
                        }
                    }
                    toolStripStatusLabel1.Text = "栏目更新成功";
                    MessageBox.Show("栏目更新成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });

        }

        private void WriteFile(string message)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\Administrator\Desktop\ColummnCompareResult.txt", false);
            foreach (string item in message.Split(','))
            {
                if (!string.IsNullOrEmpty(item))
                    sw.WriteLine(item);
            }
            sw.Close();
        }
    }
}
