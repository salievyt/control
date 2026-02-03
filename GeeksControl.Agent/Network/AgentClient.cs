using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using GeeksControl.Shared.Network;
using GeeksControl.Shared.Device;
using GeeksControl.Shared.Auth;
using GeeksControl.User.SystemControl;

namespace GeeksControl.User.Network;

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
                var cmd = JsonSerializer.Deserialize<Packet>(line);

                if (cmd.Type == "LOCK")
                    SystemController.Lock();
            }
        });
    }
}