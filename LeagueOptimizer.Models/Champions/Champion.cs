using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Models.Champions.Stats;
using LeagueOptimizer.Models.Champions.Stats.Resources;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions;

public abstract class Champion
{
    private readonly ILogger<Champion> logger;

    // todo: add method for calculating normal attack dmg
    // todo: figure out if items set stats or stats will be calculated from items
    protected Champion(StatsData data, ILogger<Champion> logger)
    {
        this.logger = logger;

        BaseStatsData = data;

        Health = new Health(data.Health, data.HealthRegen);

        Resource = new Resource(data.Resource, data.ResourceRegen, ResourceType.Mana);

        AttackDamage = new PerLevelStat(data.AttackDamage);

        AttackSpeed = new AttackSpeed(data.AttackSpeed, data.AttackSpeed.Ratio);

        Armor = new Resistance(data.Armor);

        MagicResist = new Resistance(data.MagicResist);

        AttackRange = new Stat { Base = data.AttackRange };

        MovementSpeed = new Stat { Base = data.MovementSpeed };
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

    // Health
    public Health Health { get; set; }

    // Resource
    public Resource Resource { get; set; }

    // AttackDamage
    public PerLevelStat AttackDamage { get; set; }

    // AttackSpeed
    public AttackSpeed AttackSpeed { get; set; }

    // Armor
    public Resistance Armor { get; set; }

    // ArmorPen
    public Penetration ArmorPen { get; set; } = new();

    // MagicResist
    public Resistance MagicResist { get; set; }

    // MagicPen
    public Penetration MagicPen { get; set; } = new();

    // AttackRange
    public Stat AttackRange { get; set; }

    // MovementSpeed
    public Stat MovementSpeed { get; set; }

    // AP
    public BasicStat Ap { get; set; } = new();

    // AbilityHaste
    public decimal AbilityHaste { get; set; } = 0m;

    // Lifesteal
    public decimal Lifesteal { get; set; } = 0m;

    // CritChance
    public decimal CritChance { get; set; } = 0m;

    // CritDamage
    public Stat CritDamage { get; set; } = new() { Base = 1.75m };

    override public string ToString()
    {
        return $"{Name} (Level {Level.Value}): \n" +
               $"  Health:          {Health.Total} (Regen: {Health.Regen.Total})\n" +
               $"  Resource ({Resource.ResourceType}): {Resource.Total} (Regen: {Resource.Regen.Total})\n" +
               $"  Attack Damage:   {AttackDamage.Total}\n" +
               $"  Attack Speed:    {AttackSpeed.Total:F2}\n" +
               $"  Armor:           {Armor.Total}\n" +
               $"  Magic Resist:    {MagicResist.Total}\n" +
               $"  Attack Range:    {AttackRange}\n" +
               $"  Movement Speed:  {MovementSpeed}\n" +
               $"  Ability Power:   {Ap.Total}\n" +
               $"  Ability Haste:   {AbilityHaste}\n" +
               $"  Lifesteal:       {Lifesteal:P}\n" +
               $"  Crit Chance:     {CritChance:P}\n" +
               $"  Crit Damage:     {CritDamage:P}\n";
    }
}