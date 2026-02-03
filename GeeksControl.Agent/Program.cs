using System.ServiceProcess;
using GeeksControl.User.Service;
using GeeksControl.Shared.Auth;
using GeeksControl.Shared.Security;
using GeeksControl.User.Network;

if (Environment.UserInteractive)
{
    SecurityGuard.EnsureSystem();
    var identity = DeviceIdentity.LoadOrCreate();
    var client = new AgentClient(identity);
    client.Start();
    Console.ReadLine();
}
else
{
    ServiceBase.Run(new UserAgentService());
}