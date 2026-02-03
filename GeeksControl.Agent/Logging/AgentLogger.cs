using System;
using System.IO;

namespace GeeksControl.Agent.Logging;

public static class AgentLogger
{
    private static readonly string LogPath = "agent.log";

    public static void Info(string msg) => Log("[INFO]", msg);
    public static void Warn(string msg) => Log("[WARN]", msg);
    public static void Error(string msg) => Log("[ERROR]", msg);

    private static void Log(string level, string msg)
    {
        var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {level} {msg}";
        Console.WriteLine(line);
        File.AppendAllText(LogPath, line + "\n");
    }
}