using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NetWorkSniffer
{
    public partial class Form3 : Form
    {
        private DataTable table = new DataTable();
        private DataTable real_table = new DataTable();
        private int pre = 0;
        private Timer timer;
        public int DataIndex;
        private ICaptureDevice _device;
        string[,] netstatArray=null;
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            InintProcessID();
            initDataGridView();
            showSniffList();
            timer = new Timer();
            timer.Interval = 500; // 500毫秒，即0.5秒
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 每秒钟更新 DataSource
            UpdateDataSource();
        }

        private void UpdateDataSource()
        {
            int last = table.Rows.Count;
            for (int i = pre; i < last; i++)
            {
                DataRow row = table.Rows[i];
                bool findRow = false;
                foreach (DataRow row2 in real_table.Rows)
                {
                    // 访问每一列的数据
                    if ((string)row["Local IP"] == (string)row2["Local IP"] && (string)row["Remote IP"] == (string)row2["Remote IP"] && (int)row["Local port"] == (int)row2["Local port"] && (int)row["Process ID"] == (int)row2["Process ID"])
                    {
                        findRow = true;
                        row2["In"] = (int)row["In"] + (int)row2["In"];
                        row2["Out"] = (int)row["Out"] + (int)row2["Out"];
                        row2["Bytes"] = (int)row["Bytes"] + (int)row2["Bytes"];
                        break;
                    }
                }
                if(!findRow)
                {
                    real_table.Rows.Add((string)row["Local IP"], (string)row["Remote IP"], (int)row["Local port"], (int)row["In"], (int)row["Out"], (int)row["Bytes"], (int)row["Process ID"]);
                }
            }
            pre =last;
            dataGridView1.DataSource = real_table;
            dataGridView1.Refresh();
        }

        public void showSniffList()
        {
            int dataindex = DataIndex;
            _device = CaptureDeviceList.Instance[dataindex];
            // 注册事件
            _device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
            // 开启设备，设置为混杂模式
            _device.Open(DeviceMode.Promiscuous, 1000);
            _device.StartCapture();
        }

        private void Device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            InintProcessID();
            var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            var ipPacket = packet.Extract<IPPacket>();

            if (ipPacket != null)
            {
                string sourceIp = ipPacket.SourceAddress.ToString();
                string destinationIp = ipPacket.DestinationAddress.ToString();
                var transportPacket = ipPacket.PayloadPacket; // 提取有效负载
                int sourcePort = -1;
                int destinationPort = -1;
                int processId = 0;
                if (transportPacket is TcpPacket tcpPacket)
                {
                    sourcePort=tcpPacket.SourcePort;
                    destinationPort=tcpPacket.DestinationPort;
                    if (sourcePort > 0 && destinationPort > 0)
                    {
                        string parameter1 ;
                        string parameter2 ;
                        if (sourceIp.Contains(':'))
                            parameter1 = "[" + sourceIp + "]:" + sourcePort;
                        else
                            parameter1 = sourceIp + ":" + sourcePort;
                        if (destinationIp.Contains(':'))
                            parameter2 = "[" + destinationIp + "]:" + destinationPort;
                        else
                            parameter2 = destinationIp + ":" + destinationPort;
                        processId = findProcessID("TCP", parameter1, parameter2);
                    }
                    
                }
                else if (transportPacket is UdpPacket udpPacket)
                {
                    sourcePort = udpPacket.SourcePort;
                    destinationPort = udpPacket.DestinationPort;
                    if (sourcePort > 0 && destinationPort > 0)
                    {
                        string parameter1;
                        string parameter2;
                        if (sourceIp.Contains(':'))
                            parameter1 = "[" + sourceIp + "]:" + sourcePort;
                        else
                            parameter1 = sourceIp + ":" + sourcePort;
                        if (destinationIp.Contains(':'))
                            parameter2 = "[" + destinationIp + "]:" + destinationPort;
                        else
                            parameter2 = destinationIp + ":" + destinationPort;
                        processId = findProcessID("UDP", parameter1, parameter2);
                    }
                }
                else
                {
                    Console.WriteLine("no tcp and udp");
                }

                if(processId!=0 )
                {
                    // out
                    if (processId > 0)
                    {
                            table.Rows.Add(sourceIp, destinationIp, sourcePort, 0, 1, e.Packet.Data.Length, processId);
                    }
                    else
                    {                        
                            table.Rows.Add(destinationIp, sourceIp, destinationPort, 1, 0, e.Packet.Data.Length, -processId);                       
                    }
                }
            }

        }

        private void InintProcessID()
        {
            netstatArray=null;
            // 创建一个进程来运行 netstat -ano 命令
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c netstat -ano",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                using (var reader = process.StandardOutput)
                {
                    string output = reader.ReadToEnd(); // 获取输出
                    string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); // 按行分割

                    
                    netstatArray = new string[lines.Length, 5]; 

                    for (int i = 0; i < lines.Length; i++)
                    {
                        // 处理每一行，按空格分割并填充数组
                        string[] parts = lines[i].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < parts.Length && j < 5; j++) 
                        {
                            netstatArray[i, j] = parts[j];
                        }
                    }
                }
            }
        }

        private int findProcessID(string protocal,string src,string des)
        {
            for (int i = 0; i < netstatArray.GetLength(0); i++)
            {
                if(netstatArray[i, 0] == protocal)
                {
                    if (netstatArray[i,1] == src)
                    {
                        if(netstatArray[i, 2].Contains("*"))
                            return int.Parse(netstatArray[i, 3]);
                        if(netstatArray[i, 2] == des)
                            return int.Parse(netstatArray[i, 4]);
                    }
                    if (netstatArray[i, 1] == des )
                    {
                        if (netstatArray[i, 2].Contains("*"))
                            return -int.Parse(netstatArray[i, 3]);
                        if (netstatArray[i, 2] == src)
                            return -int.Parse(netstatArray[i, 4]);
                    }
                }
            }
            return 0;
        }

        private void initDataGridView()
        {
            // 添加列
            table.Columns.Add("Local IP", typeof(string));
            table.Columns.Add("Remote IP", typeof(string));
            table.Columns.Add("Local port", typeof(int));
            table.Columns.Add("In", typeof(int));
            table.Columns.Add("Out", typeof(int));
            table.Columns.Add("Bytes", typeof(int));
            table.Columns.Add("Process ID", typeof(int));

            real_table.Columns.Add("Local IP", typeof(string));
            real_table.Columns.Add("Remote IP", typeof(string));
            real_table.Columns.Add("Local port", typeof(int));
            real_table.Columns.Add("In", typeof(int));
            real_table.Columns.Add("Out", typeof(int));
            real_table.Columns.Add("Bytes", typeof(int));
            real_table.Columns.Add("Process ID", typeof(int));

            dataGridView1.DataSource = real_table;
            // 将 DataTable 设置为 DataGridView 的数据源
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 可选: 设置列宽
            dataGridView1.Width = 700;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void stopMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataSource();
            if (_device != null)
            {
                _device.StopCapture();
                _device.Close();
            }
        }

        private void exportAsTXTFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Save as TXT File";
                saveFileDialog.FileName = "exported_data.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        // 写入列标题
                        timer.Stop();
                        string headerText = "";
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            headerText += column.HeaderText + "\t"; // 使用制表符分隔
                        }
                        writer.WriteLine(headerText.TrimEnd('\t'));

                        // 写入数据行
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow) // 忽略最后的空行
                            {
                                string rowText = "";
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    rowText += cell.Value?.ToString() + "\t"; // 使用制表符分隔
                                }
                                writer.WriteLine(rowText.TrimEnd('\t'));
                            }
                        }
                        MessageBox.Show("数据已成功导出到 " + saveFileDialog.FileName);
                    }
                }

            }
        }

        private void exportAsExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.Title = "Save as Excel File";
                saveFileDialog.FileName = "exported_data.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 创建一个 Excel 应用程序实例
                    timer.Stop();
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();
                    Excel.Worksheet worksheet = workbook.Sheets[1];

                    // 写入列标题
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        worksheet.Cells[1, col + 1] = dataGridView1.Columns[col].HeaderText;
                    }

                    // 写入数据行
                    for (int row = 0; row < dataGridView1.Rows.Count; row++)
                    {
                        if (!dataGridView1.Rows[row].IsNewRow) // 忽略空行
                        {
                            for (int col = 0; col < dataGridView1.Columns.Count; col++)
                            {
                                worksheet.Cells[row + 2, col + 1] = dataGridView1.Rows[row].Cells[col].Value?.ToString();
                            }
                        }
                    }

                    // 保存并关闭
                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("数据已成功导出到 " + saveFileDialog.FileName);
                }
            }
        }
    }
}
