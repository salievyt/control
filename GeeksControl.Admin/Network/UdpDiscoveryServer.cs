using System.Net.Sockets;
using GeeksControl.Shared.Network;

namespace GeeksControl.Admin.Network;

public class UdpDiscoveryServer
{
    public void Start()
    {
        var udp = new UdpClient(Protocol.UdpPort);
        Console.WriteLine("UDP Discovery started");
    }
}