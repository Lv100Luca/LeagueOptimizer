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
            BonusAttackDamage = 320,
            CritChance = 1m,
            BonusCritDamage = 0.4m,

            BonusAttackSpeed = 0.35m,

            TargetIsTrapped = true,
            TargetIsChampion = true,
            HasHeadshotActive = true,

        };

        Console.WriteLine(cait);

        cait.Level = Level.From(18);

        Console.WriteLine(cait);

        // Console.WriteLine("=================");
        // Console.Out.WriteLine(cait.AbilitiesToString());

        Console.WriteLine("=================");
        Console.WriteLine("Normal Attack Damage:");
        Console.Out.WriteLine("Has IE: " + cait.HasIE);
        Console.Out.WriteLine("Headshot: " + cait.HasHeadshotActive);
        Console.Out.WriteLine("Target is Trapped: " + cait.TargetIsTrapped);
        Console.WriteLine(cait.CalculateNormalAttackDamage());

        Console.WriteLine("=================");
        Console.WriteLine("Spell R Damage:");
        Console.Out.WriteLine(cait.CalculateSpellRDamage());
    }
}