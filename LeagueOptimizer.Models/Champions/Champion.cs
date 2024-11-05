using LeagueOptimizer.Models.ChampionStats;

namespace LeagueOptimizer.Models.Champions;

public abstract class Champion
{
    /// <summary>
    /// The Level of the Champion
    /// </summary>
    Level Level { get; set; }

    /// <summary>
    /// The health stat of the Champion
    /// </summary>
    Health Health { get; set; }

    /// <summary>
    /// The Health Regen stat of the Champion
    /// </summary>
    HealthRegen HealthRegen { get; set; }

    /// <summary>
    /// The Armor stat of the Champion
    /// </summary>
    AttackDamage AttackDamage { get; set; }

    /// <summary>
    /// The Attack Speed stat of the Champion
    /// </summary>
    AttackSpeed AttackSpeed { get; set; }

    /// <summary>
    /// The Magic Resist stat of the Champion
    /// </summary>
    Armor Armor { get; set; }

    /// <summary>
    /// The Magic Resist stat of the Champion
    /// </summary>
    MagicResist MagicResist { get; set; }

    /// <summary>
    /// The Attack Range stat of the Champion
    /// </summary>
    int AttackRange { get; set; }

    /// <summary>
    /// The Movement Speed stat of the Champion
    /// </summary>
    int MovementSpeed { get; set; }
}