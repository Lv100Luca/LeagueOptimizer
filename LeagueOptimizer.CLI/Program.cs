// See https://aka.ms/new-console-template for more information

using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Models;
using LeagueOptimizer.Models.Champions.Caitlyn;
using LeagueOptimizer.Models.Champions.Caitlyn.AbilityData;
using LeagueOptimizer.Models.Champions.ChampionStats;
using LeagueOptimizer.Services;
using Microsoft.Extensions.Logging;

namespace League.Optimizer.CLI;

public static class Program
{
    public static void Main(string[] args)
    {
        CalculateDamageReductionArmor();
        TestResistCalculation1();
        TestResistCalculation2();
        TestAbilityDamageCalculation();
    }

    private static void CalculateDamageReductionArmor()
    {
        var reader = new StatReader(new Logger<StatReader>(new LoggerFactory()));

        var cait = new Caitlyn(reader.ReadStats<CaitlynAbilityData>(Caitlyn.FilePath),
            new Logger<Caitlyn>(new LoggerFactory()))
        {
            ArmorPen =
            {
                FlatPen = 10
            }
        };

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
            ArmorPen = new Penetration
            {
                FlatPen = 10,
                PercentBonusPen = 0.45m,
            },
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
            AttackDamage =
            {
                Bonus = 320
            },

            CritDamage =
            {
                Bonus = 0.4m
            },

            AttackSpeed =
            {
                Bonus = 0.35m
            },

            CritChance = new BasicStat(1m),
            TargetIsTrapped = true,
            TargetIsChampion = true,
            HasHeadshotActive = true,
        };

        Console.WriteLine(cait);

        cait.Level = Level.From(18);

        Console.WriteLine(cait);

        Console.WriteLine("=================");
        Console.Out.WriteLine(cait.AbilitiesToString());

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