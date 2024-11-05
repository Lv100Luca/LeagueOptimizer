// See https://aka.ms/new-console-template for more information

using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Services;
using Microsoft.Extensions.Logging;

namespace League.Optimizer.CLI;

public static class Program
{
    public static void Main(string[] args)
    {
        var reader = new StatReader(new Logger<StatReader>(new LoggerFactory()));
        var factory = new ChampionFactory(reader, new Logger<ChampionFactory>(new LoggerFactory()));
        var cait = factory.Build(ChampionNames.Caitlyn);

        cait.Level = Level.From(3);
        cait.AttackSpeed.Bonus = 0.25;

        Console.WriteLine(cait);
    }
}