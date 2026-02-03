namespace GeeksControl.Agent.Network{
using System;
using System.IO;                // StreamReader, StreamWriter
using System.Net.Sockets;       // TcpClient
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;    // Task

// Подключаем классы из Shared
using GeeksControl.Shared.Device;    // DeviceStatusCollector
using GeeksControl.Shared.Auth;      // DeviceIdentity
using GeeksControl.Shared.Network;   // Packet, Protocol

// Подключаем SystemController для LOCK
using GeeksControl.Agent.SystemControl; 



public class AgentClient
{
    private readonly DeviceIdentity _identity;

    public AgentClient(DeviceIdentity identity)
    {
        _identity = identity;
    }

    public void Start()
    {
        var client = new TcpClient("127.0.0.1", Protocol.TcpPort);
        var stream = client.GetStream();

        var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
        var reader = new StreamReader(stream, Encoding.UTF8);

        writer.WriteLine(JsonSerializer.Serialize(new Packet { Type = "STATUS" }));

        Task.Run(async () =>
        {
            while (true)
            {
                var line = await reader.ReadLineAsync();
                if (line == null) break;

                var cmd = JsonSerializer.Deserialize<Packet>(line);

                if (cmd.Type == "LOCK")
                    SystemController.Lock();
            }
        });
    }
}
}