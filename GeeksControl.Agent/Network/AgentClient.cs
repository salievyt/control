using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using GeeksControl.Shared.DTO; // ← обязательно
using System.Threading.Tasks;
using GeeksControl.Agent.Config;
using GeeksControl.Agent.Logging;
using GeeksControl.Shared.Auth;
using GeeksControl.Shared.Network;

namespace GeeksControl.Agent.Network;

public class AgentClient
{
    private readonly DeviceIdentity _identity;
    private readonly AgentConfig _config;
    private PolicyDTO? _lastPolicy;

    public AgentClient(DeviceIdentity identity, AgentConfig config)
    {
        _identity = identity;
        _config = config;
    }

    public async Task StartAsync()
    {
        while (true)
        {
            try
            {
                AgentLogger.Info(
                    $"Connecting to Admin {_config.AdminHost}:{_config.AdminPort}..."
                );

                using var client = new TcpClient();
                using var cts = new CancellationTokenSource(
                    TimeSpan.FromSeconds(_config.ConnectTimeoutSeconds)
                );

                await client.ConnectAsync(
                    _config.AdminHost,
                    _config.AdminPort,
                    cts.Token
                );

                AgentLogger.Info("Connected to Admin");

                using var stream = client.GetStream();
                using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
                using var reader = new StreamReader(stream, Encoding.UTF8);

                // Отправляем статус
                var hello = new Packet
                {
                    Type = "STATUS",
                    Data = JsonSerializer.Serialize(_identity)
                };

                await writer.WriteLineAsync(JsonSerializer.Serialize(hello));

                // Основной цикл
                var heartbeatTask = HeartbeatAsync();
                while (client.Connected)
                {
                    var line = await reader.ReadLineAsync();
                    if (line == null) break;

                    var packet = JsonSerializer.Deserialize<Packet>(line);
                    AgentLogger.Info($"Command received: {packet?.Type}");

                    if (packet?.Type == "LOCK")
                    {
                        AgentLogger.Warn("LOCK command received");
                        // SystemController.Lock();
                    }
                }
            }
            catch (OperationCanceledException)
            {
                AgentLogger.Warn("Connection timeout");
            }
            catch (Exception ex)
            {
                AgentLogger.Error($"Connection failed: {ex.Message}");
            }

            AgentLogger.Info(
                $"Reconnect in {_config.ReconnectDelaySeconds} sec..."
            );
            await Task.Delay(_config.ReconnectDelaySeconds * 1000);
        }
    }

    private async Task HeartbeatAsync()
    {
        while (true)
        {
            AgentLogger.Info("Sending heartbeat...");
            await Task.Delay(TimeSpan.FromSeconds(30));
        }
    }

    public PolicyDTO GetCachedPolicy()
    {
        if (_lastPolicy != null) return _lastPolicy;
        return new PolicyDTO { Lock = false, BlockedSites = Array.Empty<string>() };
    }
}