using System.ServiceProcess;
using GeeksControl.User.Network;
using GeeksControl.Shared.Auth;
using GeeksControl.Shared.Security;

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
    ServiceBase.Run(new GeeksControl.User.Service.UserAgentService());
}