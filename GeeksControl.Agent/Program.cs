using System.Threading.Tasks;
using GeeksControl.Agent.Config;
using GeeksControl.Agent.Network;
using GeeksControl.Shared.Auth;
using GeeksControl.Shared.Security;

class Program
{
    static async Task Main()
    {
        SecurityGuard.EnsureSystem();

        var config = AgentConfig.Load();
        var identity = DeviceIdentity.LoadOrCreate();

        var client = new AgentClient(identity, config);
        await client.StartAsync();
    }
}