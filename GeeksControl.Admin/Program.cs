
using GeeksControl.Admin.Network;
using GeeksControl.Admin.ConsoleUI;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GeeksControl.Shared.Network;

var tcp = new TcpServer();
var udp = new UdpDiscoveryServer();

udp.Start();
tcp.Start();

AdminConsole.Run();