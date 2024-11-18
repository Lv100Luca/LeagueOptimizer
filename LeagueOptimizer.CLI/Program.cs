// See https://aka.ms/new-console-template for more information

using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Models.Champions.Caitlyn;
using LeagueOptimizer.Models.Champions.Caitlyn.AbilityData;
using LeagueOptimizer.Services;
using Microsoft.Extensions.Logging;

namespace League.Optimizer.CLI;

public static class Program
{
    public static void Main(string[] args)
    {
        var reader = new StatReader(new Logger<StatReader>(new LoggerFactory()));

        var cait = new Caitlyn(reader.ReadStats<CaitlynAbilityData>(Caitlyn.FilePath),
            new Logger<Caitlyn>(new LoggerFactory()))
        {
            Level = Level.From(7),
            CritChance = 0.50m,
        };

        cait.HasHeadshotActive = true;
        Console.WriteLine(cait);

        // Console.WriteLine("=================");
        // Console.Out.WriteLine(cait.AbilitiesToString());

        Console.WriteLine("=================");
        Console.WriteLine("Normal Attack Damage:");
        Console.WriteLine(cait.CalculateNormalAttackDamage());
    }
}