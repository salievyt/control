namespace GeeksControl.Admin.ConsoleUI;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GeeksControl.Shared.Network;

public static class AdminConsole
{
    public static void Run()
    {
        Console.WriteLine("Admin Console running");
        while (true)
        {
            var cmd = Console.ReadLine();
            if (cmd == "exit") break;
        }
    }
}