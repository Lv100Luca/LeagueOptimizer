using LeagueOptimizer.Abstractions.Champions.Data;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Abstractions.Champions;

public abstract class Champion : ITarget
{
    private readonly ILogger<Champion> logger;

    // todo: add method for calculating normal attack dmg
    // todo: figure out if items set stats or stats will be calculated from items
    protected Champion(StatsData data, ILogger<Champion> logger)
    {
        this.logger = logger;

        BaseStatsData = data;

        BaseArmor = CalculatePerLevelStat(BaseStatsData.Armor.Base, BaseStatsData.Armor.Growth);
        BaseMagicResist = CalculatePerLevelStat(BaseStatsData.MagicResist.Base, BaseStatsData.MagicResist.Growth);
    }

    public abstract string Name { get; set; }
    public Level Level { get; set; } = Level.Default;

    private StatsData BaseStatsData { get; set; }

    // Health
    public decimal BaseHp => CalculatePerLevelStat(BaseStatsData.Health.Base, BaseStatsData.Health.Growth);
    public decimal BonusHp { get; set; } = 0m;
    public decimal MaxHp => CalculateMaxHp();

    private decimal CalculateMaxHp()
    {
        // todo: add hp modifier
        return BaseHp + BonusHp;
    }

    public decimal CurrentHpPercentage { get; set; } = 1m;
    public decimal CurrentHp => CurrentHpPercentage * MaxHp;
    public decimal MissingHp => MaxHp - CurrentHp;

    // HealthRegen
    public decimal BaseHpRegen => CalculatePerLevelStat(BaseStatsData.HealthRegen.Base, BaseStatsData.HealthRegen.Growth);
    public decimal BonusHpRegen { get; set; } = 0m;
    public decimal TotalHpRegen => CalculateTotalHpRegen();

    private decimal CalculateTotalHpRegen()
    {
        // todo: add hp modifier
        return BaseHpRegen + BonusHpRegen;
    }

    // Resource
    public ResourceType ResourceType { get; set; } = ResourceType.Mana;

    public decimal BaseResource => CalculatePerLevelStat(BaseStatsData.Resource.Base, BaseStatsData.Resource.Growth);
    public decimal BonusResource { get; set; } = 0m;
    public decimal MaxResource => CalculateMaxResource();

    private decimal CalculateMaxResource()
    {
        // todo: add resource modifier
        return BaseResource + BonusResource;
    }

    public decimal CurrentResourcePercentage { get; set; } = 1m;
    public decimal CurrentResource => CurrentResourcePercentage * MaxResource;
    public decimal MissingResource => MaxResource - CurrentResource;

    // ResourceRegen
    public decimal BaseResourceRegen =>
        CalculatePerLevelStat(BaseStatsData.ResourceRegen.Base, BaseStatsData.ResourceRegen.Growth);

    public decimal BonusResourceRegen { get; set; } = 0m;
    public decimal TotalResourceRegen => CalculateTotalResourceRegen();

    private decimal CalculateTotalResourceRegen()
    {
        // todo: add resource modifier
        return BaseResourceRegen + BonusResourceRegen;
    }

    // AttackDamage
    public decimal BaseAttackDamage =>
        CalculatePerLevelStat(BaseStatsData.AttackDamage.Base, BaseStatsData.AttackDamage.Growth);

    public decimal BonusAttackDamage { get; set; } = 0m;
    public decimal TotalAttackDamage => CalculateTotalAttackDamage();

    private decimal CalculateTotalAttackDamage()
    {
        // todo: add attack damage modifier
        return BaseAttackDamage + BonusAttackDamage;
    }

    // AttackSpeed
    public decimal BaseAttackSpeed => CalculateAttackSpeed(BaseStatsData.AttackSpeed.Base, BaseStatsData.AttackSpeed.Growth,
        BonusAttackSpeed, BaseStatsData.AttackSpeed.Ratio);

    public decimal BonusAttackSpeed { get; set; } = 0m;
    public decimal TotalAttackSpeed => CalculateTotalAttackSpeed();

    private decimal CalculateTotalAttackSpeed()
    {
        // todo: add attack speed modifier
        return BaseAttackSpeed + BonusAttackSpeed;
    }

    // todo use private setting used by a function called 'ReduceResistance' or similar
    // Armor
    public decimal BaseArmor { get; set; } = 0m;
    public decimal BonusArmor { get; set; } = 0m;
    public decimal TotalArmor => CalculateTotalArmor();

    private decimal CalculateTotalArmor()
    {
        // todo: add armor modifier
        return BaseArmor + BonusArmor;
    }

    // MagicResist
    public decimal BaseMagicResist { get; set; } = 0m;
    public decimal BonusMagicResist { get; set; } = 0m;
    public decimal TotalMagicResist => CalculateTotalMagicResist();

    private decimal CalculateTotalMagicResist()
    {
        // todo: add magic resist modifier
        return BaseMagicResist + BonusMagicResist;
    }

    // AttackRange
    public decimal BaseAttackRange => BaseStatsData.AttackRange;
    public decimal BonusAttackRange { get; set; } = 0m;
    public decimal TotalAttackRange => BaseAttackRange + BonusAttackRange;

    // MovementSpeed
    public decimal BaseMovementSpeed => BaseStatsData.MovementSpeed;
    public decimal BonusMovementSpeed { get; set; } = 0m;
    public decimal TotalMovementSpeed => BaseMovementSpeed + BonusMovementSpeed;

    // AP
    public decimal BaseAp { get; set; } = 0m;
    public decimal ApMultiplier { get; set; } = 1m;

    // AbilityHaste
    public decimal AbilityHaste { get; set; } = 0m;

    // MagicPen
    public decimal FlatMagicPen { get; set; } = 0m;
    public decimal MagicPen { get; set; } = 0m;

    /// <summary>
    /// Magic Pen that only applies to bonus resistances
    /// </summary>
    public decimal BonusMagicPen { get; set; } = 0m;

    public decimal FlatMagicResistReduction { get; set; } = 0m;
    public decimal MagicResistReduction { get; set; } = 0m;

    // Lethality
    public decimal Lethality { get; set; } = 0m;
    public decimal ArmorPen { get; set; } = 0m;

    /// <summary>
    /// Armor Pen that only applies to bonus resistances
    /// </summary>
    public decimal BonusArmorPen { get; set; } = 0m;

    public decimal FlatArmorReduction { get; set; } = 0m;
    public decimal ArmorReduction { get; set; } = 0m;

    // Lifesteal
    public decimal Lifesteal { get; set; } = 0m;

    // CritChance
    public decimal CritChance { get; set; } = 0m;

    // CritDamage
    public decimal BaseCritDamage { get; set; } = 1.75m;
    public decimal BonusCritDamage { get; set; }
    public decimal CritDamage => BaseCritDamage + BonusCritDamage;

    private const decimal SchizoPerLevelMultiplier1 = 0.7025m;
    private const decimal SchizoPerLevelMultiplier2 = 0.0175m;

    private decimal CalculatePerLevelStat(decimal baseValue, decimal growth)
    {
        // formula and value can be found here:
        // https://leagueoflegends.fandom.com/wiki/Champion_statistic under #Increasing Statistics

        var g = growth;
        var n = Level.Value;

        return baseValue + (g * (n - 1) * (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1)));
    }

    private decimal CalculateAttackSpeed(decimal baseValue, decimal growth, decimal bonus, decimal ratio)
    {
        // formula and value can be found here:
        // https://leagueoflegends.fandom.com/wiki/Champion_statistic under #Increasing Statistics

        var g = growth;
        var n = Level.Value;

        return baseValue + (bonus + g * (n - 1) *
            (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1))) * ratio;
    }

    override public string ToString()
    {
        return $"{Name} (Level {Level.Value}): \n" +
               $"  Health:          {MaxHp} (Regen: {TotalHpRegen})\n" +
               $"  Resource ({ResourceType}): {MaxResource} (Regen: {TotalResourceRegen})\n" +
               $"  Attack Damage:   {TotalAttackDamage}\n" +
               $"  Attack Speed:    {TotalAttackSpeed:F2}\n" +
               $"  Armor:           {TotalArmor}\n" +
               $"  Magic Resist:    {TotalMagicResist}\n" +
               $"  Attack Range:    {TotalAttackRange}\n" +
               $"  Movement Speed:  {TotalMovementSpeed}\n" +
               $"  Ability Power:   {BaseAp * ApMultiplier}\n" +
               $"  Ability Haste:   {AbilityHaste}\n" +
               $"  Magic Pen:       {MagicPen}\n" +
               $"  Lethality:       {Lethality}\n" +
               $"  Lifesteal:       {Lifesteal:P}\n" +
               $"  Crit Chance:     {CritChance:P}\n" +
               $"  Crit Damage:     {CritDamage:P}\n";
    }

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
                target.TotalArmor, BonusArmorPen, ArmorPen, Lethality),
            DamageType.Magic => CalculateTargetResistance(target.FlatMagicResistReduction, target.MagicResistReduction,
                target.BaseMagicResist, target.BonusMagicResist,
                target.TotalMagicResist, BonusMagicPen, MagicPen, 0),
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