using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;
using LeagueOptimizer.Models.Champions.Stats;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions;

public abstract class Champion : ITarget
{
    private readonly ILogger<Champion> logger;

    // todo: add method for calculating normal attack dmg
    // todo: figure out if items set stats or stats will be calculated from items
    protected Champion(StatsData data, ILogger<Champion> logger)
    {
        this.logger = logger;

        BaseStatsData = data;

        Health = new Resource(data.Health);

        Resource = new Resource(data.Resource);

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
        Health.Update(Level);
        Resource.Update(Level);
        AttackDamage.Update(Level);
        AttackSpeed.Update(Level);
        Armor.Update(Level);
        MagicResist.Update(Level);
    }

    private StatsData BaseStatsData { get; set; }

    // Health
    public  IResource Health { get; set; }

    // Resource
    public  IResource Resource { get; set; }

    // AttackDamage
    public  IStat AttackDamage { get; set; }

    // AttackSpeed
    public  IAttackSpeed AttackSpeed { get; set; }

    // Armor
    public  IResistance Armor { get; set; }

    // ArmorPen
    public IPenetration ArmorPen { get; set; } = new Penetration();

    // MagicResist
    public  IResistance MagicResist { get; set; }

    // MagicPen
    public IPenetration MagicPen { get; set; } = new Penetration();

    // AttackRange
    public  IBasicStat AttackRange { get; set; }

    // MovementSpeed
    public  IBasicStat MovementSpeed { get; set; }

    // AP
    public IBasicStat Ap { get; set; } = new BasicStat();

    // AbilityHaste
    public decimal AbilityHaste { get; set; } = 0m;

    // Lifesteal
    public decimal Lifesteal { get; set; } = 0m;

    // CritChance
    public IBasicStat CritChance { get; set; } = new BasicStat();

    // CritDamage
    public IBasicStat CritDamage { get; set; } = new BasicStat { Base = 1.75m };

    override public string ToString()
    {
        return $"{Name} (Level {Level.Value}): \n" +
               $"  Health:          {Health.Total})\n" +
               $"  Resource: {Resource.Total}\n" +
               $"  Attack Damage:   {AttackDamage.Total}\n" +
               $"  Attack Speed:    {AttackSpeed.Total:F2}\n" +
               $"  Armor:           {Armor.Total}\n" +
               $"  Magic Resist:    {MagicResist.Total}\n" +
               $"  Attack Range:    {AttackRange.Total}\n" +
               $"  Movement Speed:  {MovementSpeed.Total}\n" +
               $"  Ability Power:   {Ap.Total}\n" +
               $"  Ability Haste:   {AbilityHaste}\n" +
               $"  Lifesteal:       {Lifesteal:P}\n" +
               $"  Crit Chance:     {CritChance.Total:P}\n" +
               $"  Crit Damage:     {CritDamage.Total:P}\n";
    }
}