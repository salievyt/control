using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using GeeksControl.Shared.Network;

namespace GeeksControl.Admin.Network;

public class TcpServer
{
    public void Start()
    {
        var listener = new TcpListener(IPAddress.Any, Protocol.TcpPort);
        listener.Start();
        Console.WriteLine("Admin TCP Server started");

        Task.Run(async () =>
        {
            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                _ = HandleClient(client);
            }
        });
    }

    private async Task HandleClient(TcpClient client)
    {
        var stream = client.GetStream();
        var reader = new StreamReader(stream, Encoding.UTF8);
        var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        while (true)
        {
            var line = await reader.ReadLineAsync();
            if (line == null) break;

            var packet = JsonSerializer.Deserialize<Packet>(line);
            Console.WriteLine($"FROM USER: {packet.Type}");

            if (packet.Type == "STATUS")
            {
                await writer.WriteLineAsync(JsonSerializer.Serialize(new Packet { Type = "LOCK" }));
            }
        }
    }
}