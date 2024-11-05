using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace NetWorkSniffer
{
    public partial class Form1 : Form
    {

        private ToolTip infoToolTip;
        private int MaxLines = 5;
        private List<string> dev_name = new List<string>();
        private List<string> HistoryLines = new List<string>();
        public string HistoryFile = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载端口选择
            LoadDevices();
            infoToolTip = new ToolTip();
            infoToolTip.ShowAlways=true;
            listBox1.MouseMove += ListBox1_MouseMove;
            listBox1.MouseLeave += ListBox1_MouseLeave;

            // 绑定双击事件
            listBox1.DoubleClick += ListBox1_DoubleClick;
            listBox2.DoubleClick += ListBox2_DoubleClick;

            //listbox2展示历史文件
            HistoryText();
        }

        private void ListBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // 获取当前鼠标位置
            int index = listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) // 检查是否在有效项上
            {
                // 获取选项的信息
                string itemText = dev_name[index];

                // 设置 ToolTip 内容
                infoToolTip.SetToolTip(listBox1, itemText);
                infoToolTip.Show(itemText, listBox1, e.Location.X + 20, e.Location.Y + 20, 5000); // 在鼠标旁边显示
            }
        }

        public void UpdatePath(string path, string filePath)
        {
            // 读取文件中的所有路径
            List<string> paths = new List<string>(File.ReadAllLines(filePath));
            if (paths.Contains(path))
            {
                paths.Remove(path);
            }
            paths.Insert(0, path);
            if (paths.Count > MaxLines)
            {
                paths = paths.GetRange(0, MaxLines);
            }
            File.WriteAllLines(filePath, paths);
            HistoryText();
        }

        private void ListBox1_MouseLeave(object sender, EventArgs e)
        {
            infoToolTip.Hide(listBox1); // 隐藏 ToolTip
        }

        private void LoadDevices()
        {
            var devices = CaptureDeviceList.Instance;

            if (devices.Count < 1)
            {
                MessageBox.Show("未找到任何网络接口");
                return;
            }
            foreach (var device in devices)
            {
                listBox1.Items.Add($"{device.Description}");
                dev_name.Add($"{device.Name}");
            }
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("请选择一个网络接口");
                return;
            }
            else
            {
                Form2 form2 = new Form2();
                form2.DataIndex = listBox1.SelectedIndex;
                form2.form1=this;
                form2.Show();
            }
        }

        private void ListBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();
                selectedItem=Regex.Replace(selectedItem, @"\s*\(.*?\)", string.Empty);
                // 显示选中项的消息框
                if (File.Exists(selectedItem))
                {
                    UpdatePath(selectedItem, HistoryFile);
                    Form4 form4 = new Form4();
                    form4.filepath = selectedItem;
                    form4.form1 = this;
                    form4.Show();
                }
                else
                    MessageBox.Show($"{selectedItem}", " 文件不存在");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                
                openFileDialog.Filter = "PCAP 文件 (*.pcap)|*.pcap|PCAPNG 文件 (*.pcapng)|*.pcapng";
                openFileDialog.Title = "选择一个文件";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取选择的文件路径
                    string filePath = openFileDialog.FileName;
                    UpdatePath(filePath, HistoryFile);
                    Form4 form4 = new Form4();
                    form4.filepath = filePath;
                    form4.form1 = this;
                    form4.Show();
                }
            }
        }

        private void HistoryText()
        {
            listBox2.Items.Clear();
            HistoryLines.Clear();
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = currentDirectory+@"\HistoryPcap.txt"; 
            HistoryFile = filePath;
            if (!File.Exists(filePath))
            {
                // 文件不存在，创建文件
                using (FileStream fs = File.Create(filePath))
                {
                }

            }
            else
            {
                try
                {
                    // 读取文件内容并将每一行添加到 List 中
                    HistoryLines.AddRange(File.ReadAllLines(filePath));
                    foreach (var item in HistoryLines)
                    {
                        if (!File.Exists(item))
                            listBox2.Items.Add(item+"(未找到)");
                        else
                        {
                            FileInfo fileInfo = new FileInfo(item);
                            listBox2.Items.Add(item + "("+(fileInfo.Length/1024)+"KB)");
                        }
                           
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误: {ex.Message}");
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string url = "https://www.example.com";

            // 打开默认浏览器并加载指定 URL
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("请选择一个网络接口");
                return;
            }
            else
            {
                Form2 form2 = new Form2();
                form2.DataIndex = listBox1.SelectedIndex;
                form2.form1 = this;
                form2.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("请选择一个网络接口");
                return;
            }
            else
            {
                Form3 form3 = new Form3();
                form3.DataIndex = listBox1.SelectedIndex;
                form3.Show();
            }
        }
    }
}
