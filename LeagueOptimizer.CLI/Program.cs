// See https://aka.ms/new-console-template for more information

using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Models;
using LeagueOptimizer.Models.Champions.Caitlyn;
using LeagueOptimizer.Models.Champions.Caitlyn.AbilityData;
using LeagueOptimizer.Services;
using Microsoft.Extensions.Logging;

namespace League.Optimizer.CLI;

public static class Program
{
    public static void Main(string[] args)
    {
        CalculateDamageReductionArmor();
        // TestResistCalculation1();
        // TestResistCalculation2();
    }

    private static void CalculateDamageReductionArmor()
    {
        var reader = new StatReader(new Logger<StatReader>(new LoggerFactory()));

        var cait = new Caitlyn(reader.ReadStats<CaitlynAbilityData>(Caitlyn.FilePath),
            new Logger<Caitlyn>(new LoggerFactory()));

        cait.Lethality = 10;

        var target = new TargetDummy
        {
            BaseArmor = 100,
            BonusArmor = 0,
        };

        Console.WriteLine(cait.CalculateResistanceDamageReduction(target, DamageType.Physical));
    }

    private static void TestResistCalculation1()
    {
        var reader = new StatReader(new Logger<StatReader>(new LoggerFactory()));

        var cait = new Caitlyn(reader.ReadStats<CaitlynAbilityData>(Caitlyn.FilePath),
            new Logger<Caitlyn>(new LoggerFactory()))
        {
            Level = Level.From(18),
            Lethality = 10,
            BonusArmorPen = 0.45m,
        };

        var target = new TargetDummy
        {
            BaseArmor = 100,
            BonusArmor = 200,

            FlatArmorReduction = 30,
            ArmorReduction = 0.3m,
        };

        cait.CalculateTargetResistance(target, DamageType.Physical);
    }

    private static void TestResistCalculation2()
    {
        var reader = new StatReader(new Logger<StatReader>(new LoggerFactory()));

        var cait = new Caitlyn(reader.ReadStats<CaitlynAbilityData>(Caitlyn.FilePath),
            new Logger<Caitlyn>(new LoggerFactory()))
        {
            Level = Level.From(18),
        };

        var target = new TargetDummy
        {
            BaseArmor = 18,
            FlatArmorReduction = 30,
        };

        cait.CalculateTargetResistance(target, DamageType.Physical);
    }

    private static void TestAbilityDamageCalculation()
    {
        var reader = new StatReader(new Logger<StatReader>(new LoggerFactory()));

        var cait = new Caitlyn(reader.ReadStats<CaitlynAbilityData>(Caitlyn.FilePath),
            new Logger<Caitlyn>(new LoggerFactory()))
        {
            Level = Level.From(18),
            BonusAttackDamage = 320,
            CritChance = 1m,
            BonusCritDamage = 0.4m,

            BonusAttackSpeed = 0.35m,

            TargetIsTrapped = true,
            TargetIsChampion = true,
            HasHeadshotActive = true,
        };

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