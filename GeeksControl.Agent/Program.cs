using System;
using GeeksControl.Shared.Auth;
using GeeksControl.Shared.Security;
using GeeksControl.Agent.Network;      // AgentClient
using GeeksControl.Agent.Service;      // UserAgentService

#if WINDOWS
using GeeksControl.Agent.Service;
using System.ServiceProcess;
#endif

class Program
{
    static void Main()
    {
#if WINDOWS
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
#else
        // Mac: запускаем как обычное консольное приложение в фоне
        SecurityGuard.EnsureSystem();
        var identity = DeviceIdentity.LoadOrCreate();
        var client = new AgentClient(identity);
        client.Start();
        Console.WriteLine("User Agent running (Mac console). Press Ctrl+C to exit.");
        while (true)
        {
            System.Threading.Thread.Sleep(1000);
        }
#endif
    }
}