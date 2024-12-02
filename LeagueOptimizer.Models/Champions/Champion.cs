using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;
using LeagueOptimizer.Models.Champions.ChampionStats;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions;

public abstract class Champion : IChampion
{
    private readonly ILogger<Champion> logger;

    // todo: add method for calculating normal attack dmg
    // todo: figure out if items set stats or stats will be calculated from items
    protected Champion(StatsData data, ILogger<Champion> logger)
    {
        this.logger = logger;

        BaseStatsData = data;

        Health = new Resource(data.Health, data.HealthRegen);

        Resource = new Resource(data.Resource, data.ResourceRegen);

        AttackDamage = new Stat(data.AttackDamage);

        AttackSpeed = new AttackSpeed(data.AttackSpeed);

        Armor = new Resistance(data.Armor);

        MagicResist = new Resistance(data.MagicResist);

        AttackRange = new BasicStat(data.AttackRange);

        MovementSpeed = new BasicStat(data.MovementSpeed);
    }

    public abstract string Name { get; set; }

    private Level _level = Level.Default;
    public Level Level
    {
        set
        {
             _level = value;
            UpdateStats();
        }
        get => _level;
    }

    private void UpdateStats()
    {
        Health.UpdateLevel(Level);
        Resource.UpdateLevel(Level);
        AttackDamage.UpdateLevel(Level);
        AttackSpeed.UpdateLevel(Level);
        Armor.UpdateLevel(Level);
        MagicResist.UpdateLevel(Level);
    }

    private StatsData BaseStatsData { get; set; }

    public IResource Health { get; set; }
    public IResource Resource { get; set; }

    public IStat AttackDamage { get; set; }
    public IStat AttackSpeed { get; set; }

    public IResistance Armor { get; set; }
    public IResistance MagicResist { get; set; }

    public IBasicStat AttackRange { get; set; }
    public IBasicStat MovementSpeed { get; set; }

    public IBasicStat AbilityPower { get; set; } = new BasicStat(0);

    public IPenetration ArmorPen { get; set; } = new Penetration();
    public IPenetration MagicPen { get; set; } = new Penetration();

    public IBasicStat AbilityHaste { get; set; } = new BasicStat(0);
    public IBasicStat Lifesteal { get; set; } = new BasicStat(0);

    public IBasicStat CritChance { get; set; } = new BasicStat(0);
    public IBasicStat CritDamage { get; set; } = new BasicStat(1.75m);

    override public string ToString()
    {
        return $"{Name} (Level {Level.Value}): \n" +
               $"  Health:          {Health.Total} (Regen: {Health.Regen.Total})\n" +
               $"  Resource:        {Resource.Total} (Regen: {Resource.Regen.Total})\n" +
               $"  Attack Damage:   {AttackDamage.Total}\n" +
               $"  Attack Speed:    {AttackSpeed.Total:F2}\n" +
               $"  Armor:           {Armor.Total}\n" +
               $"  Magic Resist:    {MagicResist.Total}\n" +
               $"  Attack Range:    {AttackRange}\n" +
               $"  Movement Speed:  {MovementSpeed}\n" +
               $"  Ability Power:   {AbilityPower.Total}\n" +
               $"  Ability Haste:   {AbilityHaste}\n" +
               $"  Lifesteal:       {Lifesteal:P}\n" +
               $"  Crit Chance:     {CritChance:P}\n" +
               $"  Crit Damage:     {CritDamage:P}\n";
    }

    // temporary members
     public decimal CalculateResistanceDamageReduction(ITarget target, DamageType damageType)
    {
        return 100m / (100m + CalculateTargetResistance(target, damageType));
    }

    public decimal CalculateTargetResistance(ITarget target, DamageType damageType)
    {
        return damageType switch
        {
            DamageType.Physical => CalculateTargetResistance(target.FlatArmorReduction, target.ArmorReduction,
                target.BaseArmor, target.BonusArmor,
                target.TotalArmor, ArmorPen.PercentBonusPen, ArmorPen.PercentPen, ArmorPen.FlatPen),
            DamageType.Magic => CalculateTargetResistance(target.FlatMagicResistReduction, target.MagicResistReduction,
                target.BaseMagicResist, target.BonusMagicResist,
                target.TotalMagicResist, MagicPen.PercentBonusPen, MagicPen.FlatPen, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
        };
    }

    public static decimal CalculateTargetResistance(
        decimal flatReduction,
        decimal percentReduction,
        decimal baseResistance,
        decimal bonusResistance,
        decimal totalResistance,
        decimal bonusPen,
        decimal percentPen,
        decimal lethality
    )
    {
        // todo create generic method for both armor and mr
        /* todo keep in mind that:
         Armor Reduction REDUCES the armor
         Penetration just ignores the armor
         */

        // Armor Reduction
        // Flat armor reduction
        if (flatReduction > 0)
        {
            var newTotal = totalResistance - flatReduction;
            var flatReductionscalingFactor = newTotal / totalResistance;

            baseResistance *= flatReductionscalingFactor;
            bonusResistance *= flatReductionscalingFactor;

            totalResistance = baseResistance + bonusResistance;

            if (totalResistance < 0)
            {
                Console.Out.WriteLine($"Armor({totalResistance:F1}) is lower than 0, exiting");

                return totalResistance;
            }

            Console.Out.WriteLine(
                $"Armor after flat reduction: ({baseResistance:F1}/{bonusResistance:F1}) {totalResistance:F1}");
        }


        // percent reduction
        if (percentReduction > 0)
        {
            var percentReductionScalingFactor = 1 - percentReduction;
            baseResistance *= percentReductionScalingFactor;
            bonusResistance *= percentReductionScalingFactor;

            totalResistance = baseResistance + bonusResistance;

            Console.Out.WriteLine(
                $"Armor after percent reduction: ({baseResistance:F1}/{bonusResistance:F1}) {totalResistance:F1}");
        }

        var totalArmor = totalResistance;

        // Percent Bonus Armor Pen
        if (bonusPen > 0)
        {
            var percentBonusArmorPenScalingFactor = 1 - bonusPen;

            totalArmor = baseResistance + (bonusResistance * percentBonusArmorPenScalingFactor);

            Console.Out.WriteLine($"Armor after percent bonus pen: {totalArmor:F1}");
        }

        //Percent Armor Pen
        // todo how does total and bonus armor pen work together?
        if (percentPen > 0)
        {
            var percentArmorPenScalingFactor = 1 - percentPen;

            totalArmor *= percentArmorPenScalingFactor;

            Console.Out.WriteLine($"Armor after percent armor pen: {totalArmor:F1}");
        }

        // Flat Armor Pen
        if (lethality > 0)
        {
            totalArmor -= lethality;

            Console.Out.WriteLine($"Armor after flat armor pen: {totalArmor:F1}");
        }

        return totalArmor;
    }
}