using System.IO;
using System.Text.Json;

namespace GeeksControl.Agent.Config;

public class AgentConfig
{
    public string AdminHost { get; set; } = "127.0.0.1";
    public int AdminPort { get; set; } = 5050;
    public int ReconnectDelaySeconds { get; set; } = 5;
    public int ConnectTimeoutSeconds { get; set; } = 3;
    public string BackendUrl { get; set; } = "http://127.0.0.1:8000/api/policy/";
    public string Token { get; set; } = "";

    public static AgentConfig Load()
    {
        const string path = "agent.config.json";

        if (!File.Exists(path))
        {
            var def = new AgentConfig();
            File.WriteAllText(path, JsonSerializer.Serialize(def, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
            return def;
        }

        return JsonSerializer.Deserialize<AgentConfig>(
            File.ReadAllText(path)
        )!;
    }
}