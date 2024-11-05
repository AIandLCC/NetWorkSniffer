﻿using SharpPcap.LibPcap;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketDotNet;
using System.IO;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace NetWorkSniffer
{
    public partial class Form4 : Form
    {
        public string filepath = "";
        private DataTable table = new DataTable();
        private int totalNumber = 0;
        Dictionary<int, SharpPcap.RawCapture> dictionary = new Dictionary<int, SharpPcap.RawCapture>();
        List<SelfPacket> Selfpackets = new List<SelfPacket>();
        private CaptureFileWriterDevice pcapWriter;
        public Form1 form1 = new Form1();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            initDataGridView();
            InitFileRead();
            textBox1.Height = 100;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void InitFileRead()
        {
            var device = new CaptureFileReaderDevice(filepath);
            device.Open();
            dictionary = new Dictionary<int, SharpPcap.RawCapture>();
            // 读取每个数据包
            device.OnPacketArrival += new PacketArrivalEventHandler(OnPacketArrival);
            device.Capture();

            // 关闭文件
            device.Close();
        }

        public static string IdentifyApplicationProtocol(int sourcePort, int destPort, string protocolType)
        {
            // 确保 protocolType 参数正确
            protocolType = protocolType.ToUpper();

            // 基于 TCP 的常见应用层协议端口
            if (protocolType == "TCP")
            {
                if (sourcePort == 80 || destPort == 80) return "HTTP";
                if (sourcePort == 21 || destPort == 21) return "FTP";
                if (sourcePort == 25 || destPort == 25) return "SMTP";
                if (sourcePort == 110 || destPort == 110) return "POP3";
                if (sourcePort == 143 || destPort == 143) return "IMAP";
                if (sourcePort == 22 || destPort == 22) return "SSH";
                if (sourcePort == 23 || destPort == 23) return "Telnet";
                if (sourcePort == 3389 || destPort == 3389) return "RDP";
                if (sourcePort == 445 || destPort == 445) return "SMB";
                if (sourcePort == 389 || destPort == 389) return "LDAP";
                if (sourcePort == 465 || destPort == 465) return "SMTPS";
                if (sourcePort == 587 || destPort == 587) return "SMTP (STARTTLS)";
                if (sourcePort == 993 || destPort == 993) return "IMAPS";
                if (sourcePort == 995 || destPort == 995) return "POP3S";
            }
            // 基于 UDP 的常见应用层协议端口
            else if (protocolType == "UDP")
            {
                if (sourcePort == 53 || destPort == 53) return "DNS";
                if (sourcePort == 67 || destPort == 67) return "DHCP Server";
                if (sourcePort == 68 || destPort == 68) return "DHCP Client";
                if (sourcePort == 123 || destPort == 123) return "NTP";
                if (sourcePort == 161 || destPort == 161) return "SNMP Query";
                if (sourcePort == 162 || destPort == 162) return "SNMP Trap";
            }

            // 若无匹配协议，则返回协议类型
            return protocolType;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 检查双击的是否是有效的行（e.RowIndex 不应为 -1）
            if (e.RowIndex >= 0)
            {
                initTreeView((int)(dataGridView1.Rows[e.RowIndex].Cells[0].Value));
            }
        }
        private void OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            var ethernetFrame = packet.Extract<EthernetPacket>();
            var ipPacket = packet.Extract<IPPacket>();  // 使用 IPPacket

            if (ipPacket != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"数据包到达时间: {e.Packet.Timeval.Date}");
                sb.AppendLine($"源 IP 地址: {ipPacket.SourceAddress}");
                sb.AppendLine($"源 MAC 地址: {ethernetFrame.SourceHardwareAddress}");
                sb.AppendLine($"目标 MAC 地址: {ethernetFrame.DestinationHardwareAddress}");
                sb.AppendLine($"目标 IP 地址: {ipPacket.DestinationAddress}");
                sb.AppendLine($"数据包长度: {ipPacket.PayloadLength} 字节");

                //MAC地址
                string sourceHwAddress = ethernetFrame.SourceHardwareAddress.ToString();
                string dstHwAddress = ethernetFrame.DestinationHardwareAddress.ToString();
                // 每两个字符插入一个 ":"
                string srcformattedMacAddress = string.Join(":", Enumerable.Range(0, sourceHwAddress.Length / 2)
                                                                        .Select(i => sourceHwAddress.Substring(i * 2, 2)));

                string dstformattedMacAddress = string.Join(":", Enumerable.Range(0, dstHwAddress.Length / 2)
                                                                        .Select(i => dstHwAddress.Substring(i * 2, 2)));

                // 尝试提取 TCP 或 UDP 数据包
                var transportPacket = ipPacket.PayloadPacket; // 提取有效负载
                string unixTimestampSeconds = e.Packet.Timeval.ToString();

                int portnumber = 0;

                if (transportPacket is TcpPacket tcpPacket)
                {
                    sb.AppendLine("协议: TCP");
                    sb.AppendLine($"源端口: {tcpPacket.SourcePort}");
                    sb.AppendLine($"目标端口: {tcpPacket.DestinationPort}");
                    portnumber = tcpPacket.SourcePort;

                    dictionary.Add(++totalNumber, e.Packet);
                    Selfpackets.Add(new SelfPacket(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress.ToString(), ipPacket.DestinationAddress.ToString(), tcpPacket.SourcePort, tcpPacket.DestinationPort, "TCP", e.Packet.Data.Length, BitConverter.ToString(e.Packet.Data).Replace("-", " "), srcformattedMacAddress, dstformattedMacAddress));
                    string AppPro = IdentifyApplicationProtocol(tcpPacket.SourcePort, tcpPacket.DestinationPort, "TCP");
                    table.Rows.Add(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress, ipPacket.DestinationAddress, AppPro, e.Packet.Data.Length + "B");

                }
                else if (transportPacket is UdpPacket udpPacket)
                {
                    sb.AppendLine("协议: UDP");
                    sb.AppendLine($"源端口: {udpPacket.SourcePort}");
                    sb.AppendLine($"目标端口: {udpPacket.DestinationPort}");
                    portnumber = udpPacket.SourcePort;

                    dictionary.Add(++totalNumber, e.Packet);
                    Selfpackets.Add(new SelfPacket(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress.ToString(), ipPacket.DestinationAddress.ToString(), udpPacket.SourcePort, udpPacket.DestinationPort, "UDP", e.Packet.Data.Length, BitConverter.ToString(e.Packet.Data).Replace("-", " "), srcformattedMacAddress, dstformattedMacAddress));
                    string AppPro=IdentifyApplicationProtocol(udpPacket.SourcePort, udpPacket.DestinationPort, "UDP");
                    table.Rows.Add(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress, ipPacket.DestinationAddress, AppPro, e.Packet.Data.Length + "B");

                }
                else if (ipPacket.Protocol == PacketDotNet.ProtocolType.Icmp)
                {
                    dictionary.Add(++totalNumber, e.Packet);
                    Selfpackets.Add(new SelfPacket(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress.ToString(), ipPacket.DestinationAddress.ToString(),-1,-1, "IP", e.Packet.Data.Length, BitConverter.ToString(e.Packet.Data).Replace("-", " "), srcformattedMacAddress, dstformattedMacAddress));
                    string AppPro = "ICMP";
                    table.Rows.Add(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress, ipPacket.DestinationAddress, AppPro, e.Packet.Data.Length + "B");

                }
                else if (ipPacket.Protocol == PacketDotNet.ProtocolType.IcmpV6)
                {
                    dictionary.Add(++totalNumber, e.Packet);
                    Selfpackets.Add(new SelfPacket(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress.ToString(), ipPacket.DestinationAddress.ToString(), -1, -1, "IP", e.Packet.Data.Length, BitConverter.ToString(e.Packet.Data).Replace("-", " "), srcformattedMacAddress, dstformattedMacAddress));
                    string AppPro = "ICMPV6";
                    table.Rows.Add(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress, ipPacket.DestinationAddress, AppPro, e.Packet.Data.Length + "B");
                    int rowIndex = dataGridView1.Rows.Count - 1;
                    dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(128, 200, 255, 200); // 淡绿
                    
                }
                else if (ipPacket.Protocol == PacketDotNet.ProtocolType.Igmp)
                {
                    dictionary.Add(++totalNumber, e.Packet);
                    Selfpackets.Add(new SelfPacket(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress.ToString(), ipPacket.DestinationAddress.ToString(), -1, -1, "IP", e.Packet.Data.Length, BitConverter.ToString(e.Packet.Data).Replace("-", " "), srcformattedMacAddress, dstformattedMacAddress));
                    string AppPro = "IGMP";
                    table.Rows.Add(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress, ipPacket.DestinationAddress, AppPro, e.Packet.Data.Length + "B");

                }
                else if (ipPacket.Protocol == PacketDotNet.ProtocolType.IPv4)
                {
                    dictionary.Add(++totalNumber, e.Packet);
                    Selfpackets.Add(new SelfPacket(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress.ToString(), ipPacket.DestinationAddress.ToString(), -1, -1, "IP", e.Packet.Data.Length, BitConverter.ToString(e.Packet.Data).Replace("-", " "), srcformattedMacAddress, dstformattedMacAddress));
                    string AppPro = "IPV4";
                    table.Rows.Add(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress, ipPacket.DestinationAddress, AppPro, e.Packet.Data.Length + "B");

                }
                else if (ipPacket.Protocol == PacketDotNet.ProtocolType.IPv6)
                {
                    dictionary.Add(++totalNumber, e.Packet);
                    Selfpackets.Add(new SelfPacket(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress.ToString(), ipPacket.DestinationAddress.ToString(), -1, -1, "IP", e.Packet.Data.Length, BitConverter.ToString(e.Packet.Data).Replace("-", " "), srcformattedMacAddress, dstformattedMacAddress));
                    string AppPro = "IPV6";
                    table.Rows.Add(totalNumber, unixTimestampSeconds.ToString(), ipPacket.SourceAddress, ipPacket.DestinationAddress, AppPro, e.Packet.Data.Length + "B");

                }
                else
                {
                    sb.AppendLine("协议: 未知");
                }

                // 显示完整数据包的十六进制数据
                sb.AppendLine("完整数据包内容 (十六进制):");
                sb.AppendLine(BitConverter.ToString(e.Packet.Data).Replace("-", " "));

            }

        }
        private void initDataGridView()
        {
            // 添加列
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Source", typeof(string));
            table.Columns.Add("Destination", typeof(string));
            table.Columns.Add("Protocal", typeof(string));
            table.Columns.Add("length", typeof(string));
            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;
        }

        private void initTreeView(int rowIndex)
        {
            treeView1.Nodes.Clear();
            SelfPacket packet = Selfpackets[rowIndex - 1];

            //frame 节点
            var frame = new TreeNode("Frame " + rowIndex + ": " + packet.Length + "bytes on wire(" + packet.Length * 8 + " bits)");
            frame.Nodes.Add("Arrival Time : " + packet.Timestamp);
            frame.Nodes.Add("Frame Number : " + rowIndex);
            frame.Nodes.Add("Frame Length : " + packet.Length + "bytes on wire(" + packet.Length * 8 + " bits)");

            // Ethernet 层节点
            var ethernetNode = new TreeNode("Ethernet II");
            ethernetNode.Nodes.Add("Src: " + packet.SourceHwAddress);
            ethernetNode.Nodes.Add("Dst: " + packet.DestinationHwAddress);

            // IP 层节点
            var ipNode = new TreeNode("Internet Protocol" + " ,Src IP: " + packet.SourceIP + " ,Dst IP: " + packet.DestinationIP);
            ipNode.Nodes.Add("Src IP: " + packet.SourceIP);
            ipNode.Nodes.Add("Dst IP: " + packet.DestinationIP);

            // 传输层节点
            string tmp = "";
            if (packet.Protocol == "TCP")
                tmp = "Transmission Control Protocol (TCP)";
            else if (packet.Protocol == "UDP")
                tmp = "User Datagram Protocol (UDP)";
            var tcpNode = new TreeNode(tmp + ",Src Port: " + packet.SourcePort + ",Dst Port: " + packet.DestinationPort);
            tcpNode.Nodes.Add("Src Port: " + packet.SourcePort);
            tcpNode.Nodes.Add("Dst Port: " + packet.DestinationPort);

            // 数据节点
            var dataNode = new TreeNode("Data" + " Length: " + packet.Length);
            dataNode.Nodes.Add("Length: " + packet.Length);

            // 将各层次节点添加到包节点
            treeView1.Nodes.Add(frame);
            treeView1.Nodes.Add(ethernetNode);
            treeView1.Nodes.Add(ipNode);
            treeView1.Nodes.Add(tcpNode);
            treeView1.Nodes.Add(dataNode);

            DisplayHexData(packet.Payload);
        }

        private void DisplayHexData(string hexData)
        {
            listBox1.Items.Clear(); 
            string[] bytes = hexData.Trim().Split(' ');

            StringBuilder sbHex = new StringBuilder();
            StringBuilder sbChars = new StringBuilder();
            int byteCount = 0;
            int lineNumber = 0;

            foreach (string byteStr in bytes)
            {
                
                sbHex.AppendFormat("{0,2} ", byteStr); 
                if (byte.TryParse(byteStr, System.Globalization.NumberStyles.HexNumber, null, out byte byteValue))
                {
                    if (byteValue >= 32 && byteValue <= 126)
                    {
                        sbChars.Append((char)byteValue); // 可打印字符
                    }
                    else
                    {
                        sbChars.Append('.'); // 不可打印字符用点表示
                    }
                }
                else
                {
                    sbChars.Append('.'); // 如果解析失败，默认用点表示
                }

                byteCount++;

                // 每 16 个字节换行
                if (byteCount == 16)
                {
                    // 添加格式化后的字符串和对应字符到 ListBox
                    listBox1.Items.Add($"{lineNumber:X4}" + "\t" + sbHex.ToString().Trim() + "\t" + sbChars.ToString());
                    sbHex.Clear(); // 清空十六进制字符串
                    sbChars.Clear(); // 清空字符字符串
                    byteCount = 0; // 重置计数
                    lineNumber += 16;
                }
            }

            // 添加剩余字节（如果有）
            if (byteCount > 0)
            {
                if (byteCount <= 4)
                    listBox1.Items.Add($"{lineNumber:X4}" + "\t" + sbHex.ToString().Trim() + "\t\t\t\t\t\t" + sbChars.ToString());
                else if (byteCount <= 8)
                    listBox1.Items.Add($"{lineNumber:X4}" + "\t" + sbHex.ToString().Trim() + "\t\t\t\t\t" + sbChars.ToString());
                else if (byteCount < 10)
                    listBox1.Items.Add($"{lineNumber:X4}" + "\t" + sbHex.ToString().Trim() + "\t\t\t\t" + sbChars.ToString());
                else if (byteCount <= 12)
                    listBox1.Items.Add($"{lineNumber:X4}" + "\t" + sbHex.ToString().Trim() + "\t\t\t" + sbChars.ToString());
                else if (byteCount <= 16)
                    listBox1.Items.Add($"{lineNumber:X4}" + "\t" + sbHex.ToString().Trim() + "\t\t" + sbChars.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string filterExpression = textBox1.Text;
            filterExpression = Regex.Replace(filterExpression, @"!=", "<>");
            filterExpression = Regex.Replace(filterExpression, @"==", "=");

            try
            {
             
                DataView dv = new DataView(table); 
                dv.RowFilter = filterExpression;

                dataGridView1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"过滤条件无效: {ex.Message}");
            }
        }

        private void aNDSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
              
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                string columnName = dataGridView1.Columns[columnIndex].Name;

                object cellValue = dataGridView1.CurrentCell.Value;

                textBox1.Text = "(" + textBox1.Text + ") and " + columnName + " == '" + cellValue + "'";
            }
        }

        private void aNDNotSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
  
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                string columnName = dataGridView1.Columns[columnIndex].Name;

                object cellValue = dataGridView1.CurrentCell.Value;

                textBox1.Text = "(" + textBox1.Text + ") and " + columnName + " != '" + cellValue + "'";
            }
        }

        private void oRSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                string columnName = dataGridView1.Columns[columnIndex].Name;

                object cellValue = dataGridView1.CurrentCell.Value;

                textBox1.Text = "(" + textBox1.Text + ") or " + columnName + " == '" + cellValue + "'";
            }
        }

        private void oRNotSellectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                string columnName = dataGridView1.Columns[columnIndex].Name;

                object cellValue = dataGridView1.CurrentCell.Value;

                textBox1.Text = "(" + textBox1.Text + ") or " + columnName + " != '" + cellValue + "'";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                dataGridView1.ContextMenuStrip = contextMenuStrip2;
            }
            else
            {
                dataGridView1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void selectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
              
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                string columnName = dataGridView1.Columns[columnIndex].Name;

                object cellValue = dataGridView1.CurrentCell.Value;

                textBox1.Text = columnName + " == '" + cellValue + "'";
            }
        }

        private void notSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
            
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                string columnName = dataGridView1.Columns[columnIndex].Name;

                object cellValue = dataGridView1.CurrentCell.Value;

                textBox1.Text = columnName + " != '" + cellValue + "'";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
          
                openFileDialog.Filter = "PCAP 文件 (*.pcap)|*.pcap|PCAPNG 文件 (*.pcapng)|*.pcapng";
                openFileDialog.Title = "选择一个文件";

                // 显示对话框并检查用户选择的结果
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取选择的文件路径
                    filepath = openFileDialog.FileName;
                    totalNumber = 0;
                    Selfpackets.Clear();
                    table.Clear();
                    InitFileRead();
                    dataGridView1.DataSource = table;
                    dataGridView1.Refresh();
                    form1.UpdatePath(filepath,form1.HistoryFile);
                }
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

        private void exportAsPcapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 初始化并打开 pcapWriter，用于写入抓取的包
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PCAP files (*.pcap)|*.pcap|All files (*.*)|*.*"; // 只允许选择.pcap文件
                saveFileDialog.Title = "Save PCAP File";
                saveFileDialog.DefaultExt = "pcap"; // 默认扩展名
                saveFileDialog.AddExtension = true; // 添加扩展名
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }
               
                    pcapWriter = new CaptureFileWriterDevice(saveFileDialog.FileName);
                    pcapWriter.Open();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
           
                        if (!row.IsNewRow)
                        {
                         
                            int firstColumnValue = (int)row.Cells[0].Value; 
                            pcapWriter.Write(dictionary[firstColumnValue]);
                           
                            Console.WriteLine(firstColumnValue); 
                        }
                    }
                    pcapWriter.Close();
                    MessageBox.Show("数据已成功导出到 " + saveFileDialog.FileName);
                }
                
            }
            
        }
    }
}
