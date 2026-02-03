using System.ServiceProcess;
using GeeksControl.Shared.Auth;
using GeeksControl.Shared.Security;
using GeeksControl.User.Network;

namespace GeeksControl.User.Service;

public class UserAgentService : ServiceBase
{
    protected override void OnStart(string[] args)
    {
        SecurityGuard.EnsureSystem();

        var identity = DeviceIdentity.LoadOrCreate();
        var client = new AgentClient(identity);
        client.Start();
    }
}