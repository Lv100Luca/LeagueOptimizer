// See https://aka.ms/new-console-template for more information

using LeagueOptimizer.Services;
using Microsoft.Extensions.Logging;

namespace League.Optimizer.CLI;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var reader = new StatReader(new Logger<StatReader>(new LoggerFactory()));

        var stats = reader.ReadStats(@"Champions/Caitlyn/Caitlyn.json");

        if (stats == null)
        {
            Console.WriteLine("Failed to read stats");

            return;
        }

        Console.WriteLine(stats);
    }
}