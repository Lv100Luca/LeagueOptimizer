using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Stats.Resources;
using LeagueOptimizer.Abstractions.Stats;
using LeagueOptimizer.Models.ChampionStats;

namespace LeagueOptimizer.Models.Champions;

public abstract class Champion : IChampion
{
    public Level Level { get; set; } = Level.Default;

    // values set per champion
    public IPerLevelStat Health { get; set; }
    public IPerLevelStat HealthRegen { get; set; }
    public ResourceType ResourceType { get; set; } = ResourceType.Mana;
    public IPerLevelStat Resource { get; set; }
    public IPerLevelStat ResourceRegen { get; set; }
    public IPerLevelStat AttackDamage { get; set; }
    public IPerLevelStat AttackSpeed { get; set; }
    public IPerLevelStat Armor { get; set; }
    public IPerLevelStat MagicResist { get; set; }

    public IStat AttackRange { get; set; }
    public IStat MovementSpeed { get; set; }

    // values set by items and runes
    public IStat AbilityPower { get; set; }
    public IStat AbilityHaste { get; set; }
    public IStat MagicPenetration { get; set; }
    public IStat Lethality { get; set; }
    public IStat Lifesteal { get; set; }
    public IStat CriticalStrike { get; set; }
    public IStat CriticalStrikeDamage { get; set; }
}