namespace GeeksControl.Admin.ConsoleUI;

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