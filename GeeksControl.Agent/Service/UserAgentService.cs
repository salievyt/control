using GeeksControl.Shared.Auth;
using GeeksControl.Shared.Security;
using GeeksControl.Agent.Network;

#if WINDOWS
using System.ServiceProcess;
#endif


namespace GeeksControl.Agent.Service{

#if WINDOWS
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
#endif
}