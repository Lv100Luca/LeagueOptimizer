// See https://aka.ms/new-console-template for more information

using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Models.Champions.Caitlyn;
using LeagueOptimizer.Services;
using Microsoft.Extensions.Logging;

namespace League.Optimizer.CLI;

public static class Program
{
    public static void Main(string[] args)
    {
        var reader = new StatReader(new Logger<StatReader>(new LoggerFactory()));
        var factory = new ChampionFactory(reader, new Logger<ChampionFactory>(new LoggerFactory()));
        // todo fix casting
        var cait = (Caitlyn)factory.Build(ChampionNames.Caitlyn);

        cait.Level = Level.From(3);

        cait.AttackDamage.Base = 100;
        cait.AttackDamage.Growth = 0;
        cait.AttackSpeed.Bonus = 0.25m;
        cait.AbilityPower.Bonus = 100m;
        cait.CritChance.Bonus = 0.50m;

        Console.WriteLine(cait);

        Console.WriteLine("=================");
        Console.WriteLine("Normal Attack Damage:");
        Console.WriteLine(cait.CalculateNormalAttackDamage());
    }
}