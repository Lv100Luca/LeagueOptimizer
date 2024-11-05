using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats.Resources;
using LeagueOptimizer.Abstractions.Stats;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions;

public abstract class Champion : IChampion
{
    private readonly ILogger<Champion> logger;

    protected Champion(ChampionData data, ILogger<Champion> logger)
    {
        this.logger = logger;

        Level = Level.Default;

        // values set from data
        Health = new PerLevelStat(data.BaseStatsData.Health);
        HealthRegen = new PerLevelStat(data.BaseStatsData.HealthRegen);
        Resource = new PerLevelStat(data.BaseStatsData.Resource);
        ResourceRegen = new PerLevelStat(data.BaseStatsData.ResourceRegen);
        AttackDamage = new PerLevelStat(data.BaseStatsData.AttackDamage);
        AttackSpeed = new AttackSpeed(data.BaseStatsData.AttackSpeed.Base, data.BaseStatsData.AttackSpeed.Growth, data.BaseStatsData.AttackSpeed.Ratio);
        Armor = new PerLevelStat(data.BaseStatsData.Armor);
        MagicResist = new PerLevelStat(data.BaseStatsData.MagicResist);

        AttackRange = new Stat(data.BaseStatsData.AttackRange);
        MovementSpeed = new Stat(data.BaseStatsData.MovementSpeed);

        // initialize values with defaults
        AbilityPower = new Stat(0);
        AbilityHaste = new Stat(0);
        MagicPen = new Stat(0);
        Lethality = new Stat(0);
        Lifesteal = new Stat(0);
        CritChance = new Stat(0);
        CritDamage = new Stat(1.75);
    }

    public abstract string Name { get; set; }
    public Level Level { get; set; }

    // values set per champion
    public IPerLevelStat Health { get; set; }
    public IPerLevelStat HealthRegen { get; set; }
    public ResourceType ResourceType { get; set; } = ResourceType.Mana;
    public IPerLevelStat Resource { get; set; }
    public IPerLevelStat ResourceRegen { get; set; }
    public IPerLevelStat AttackDamage { get; set; }
    public AttackSpeed AttackSpeed { get; set; }
    public IPerLevelStat Armor { get; set; }
    public IPerLevelStat MagicResist { get; set; }

    public IStat AttackRange { get; set; }
    public IStat MovementSpeed { get; set; }

    // values set by items and runes
    public IStat AbilityPower { get; set; }
    public IStat AbilityHaste { get; set; }
    public IStat MagicPen { get; set; }
    public IStat Lethality { get; set; }
    public IStat Lifesteal { get; set; }
    public IStat CritChance { get; set; }
    public IStat CritDamage { get; set; }

    override public string ToString()
    {
        return $"{Name} ({Level}): \n" +
               $"  Health:          {Health.Total(Level)}\n" +
               $"  Health Regen:    {HealthRegen.Total(Level)}\n" +
               $"  Resource:        {Resource.Total(Level)}\n" +
               $"  Resource Regen:  {ResourceRegen.Total(Level)}\n" +
               $"  Attack Damage:   {AttackDamage.Total(Level)}\n" +
               $"  Attack Speed:    {AttackSpeed.Total(Level)}\n" +
               $"  Armor:           {Armor.Total(Level)}\n" +
               $"  Attack Range:    {AttackRange.Total}\n" +
               $"  Movement Speed:  {MovementSpeed.Total}\n" +
               $"  Ability Power:   {AbilityPower.Total}\n" +
               $"  Ability Haste:   {AbilityHaste.Total}\n" +
               $"  Magic Pen:       {MagicPen.Total}\n" +
               $"  Lethality:       {Lethality.Total}\n" +
               $"  Lifesteal:       {Lifesteal.Total}\n" +
               $"  Crit Chance:     {CritChance.Total}\n" +
               $"  Crit Damage:     {CritDamage.Total}";
    }
}