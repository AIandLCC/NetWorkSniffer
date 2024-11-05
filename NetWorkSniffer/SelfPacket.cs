using System;

namespace NetWorkSniffer
{
    internal class SelfPacket
    {
        public string Number { get; set; }                   // 数量
        public string Timestamp { get; set; }                 // 时间
        public string SourceIP { get; set; }                  // 源 IP 地址
        public string DestinationIP { get; set; }             // 目的 IP 地址
        public int SourcePort { get; set; }                   // 源端口
        public int DestinationPort { get; set; }              // 目的端口
        public string Protocol { get; set; }                  // 协议 (TCP、UDP等)
        public int Length { get; set; }                       // 报文长度
        public string Payload { get; set; }                   // 报文内容 (十六进制字符串或文本)
        public string SourceHwAddress { get; set; }           // 源 MAC 地址
        public string DestinationHwAddress { get; set; }      // 目的 MAC 地址

        // 构造函数
        public SelfPacket(int number, string timestamp, string sourceIP, string destinationIP,
                          int sourcePort, int destinationPort, string protocol, int length,
                          string payload, string sourceHwAddress, string destinationHwAddress)
        {
            Number = number.ToString(); // 将数量转换为字符串
            Timestamp = timestamp;
            SourceIP = sourceIP;
            DestinationIP = destinationIP;
            SourcePort = sourcePort;
            DestinationPort = destinationPort;
            Protocol = protocol;
            Length = length;
            Payload = payload;
            SourceHwAddress = sourceHwAddress;
            DestinationHwAddress = destinationHwAddress;
        }

        // 重写 ToString 方法，方便展示数据包信息
        public override string ToString()
        {
            return $"No.: {Number}\n" +
                   $"时间: {Timestamp}\n" +
                   $"源 IP: {SourceIP}\n" +
                   $"目的 IP: {DestinationIP}\n" +
                   $"源端口: {SourcePort}\n" +
                   $"目的端口: {DestinationPort}\n" +
                   $"协议: {Protocol}\n" +
                   $"长度: {Length} 字节\n" +
                   $"报文: {Payload}\n" +
                   $"源 MAC: {SourceHwAddress}\n" +
                   $"目的 MAC: {DestinationHwAddress}\n";
        }
    }
}
