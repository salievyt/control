using GeeksControl.Admin.Network;
using GeeksControl.Admin.ConsoleUI;

var tcp = new TcpServer();
var udp = new UdpDiscoveryServer();

udp.Start();
tcp.Start();

AdminConsole.Run();