using System.ComponentModel.DataAnnotations;
using LeagueOptimizer.Abstractions.Champions.Stats.Resources;
using LeagueOptimizer.Abstractions.Stats;

namespace LeagueOptimizer.Abstractions.Champions;

// todo use value object of IStat for each stat
public interface IChampion
{
    /// <summary>
    /// The Level of the Champion
    /// </summary>
    [Required]
    Level Level { get; set; }

    /// <summary>
    /// The health stat of the Champion
    /// </summary>
    IPerLevelStat Health { get; set; }

    /// <summary>
    /// The Health Regen stat of the Champion
    /// </summary>
    IPerLevelStat HealthRegen { get; set; }

    /// <summary>
    /// The <see cref="ResourceType"/> of the Champion
    /// </summary>
    ResourceType ResourceType { get; set; }

    /// <summary>
    /// The Resource stat of the Champion
    /// </summary>
    /// <seealso cref="ResourceType"/>
    IPerLevelStat Resource { get; set; }

    /// <summary>
    /// The Resource Regen stat of the Champion
    /// </summary>
    /// <seealso cref="ResourceType"/>
    IPerLevelStat ResourceRegen { get; set; }

    /// <summary>
    /// The Armor stat of the Champion
    /// </summary>
    IPerLevelStat AttackDamage { get; set; }

    /// <summary>
    /// The Attack Speed stat of the Champion
    /// </summary>
    AttackSpeed AttackSpeed { get; set; }

    /// <summary>
    /// The Magic Resist stat of the Champion
    /// </summary>
    IPerLevelStat Armor { get; set; }

    /// <summary>
    /// The Magic Resist stat of the Champion
    /// </summary>
    IPerLevelStat MagicResist { get; set; }

    /// <summary>
    /// The Attack Range stat of the Champion
    /// </summary>
    IStat AttackRange { get; set; }

    /// <summary>
    /// The Movement Speed stat of the Champion
    /// </summary>
    IStat MovementSpeed { get; set; }

    IStat AbilityPower { get; set; }

    IStat AbilityHaste { get; set; }

    IStat MagicPen { get; set; }

    IStat Lethality { get; set; }

    IStat Lifesteal { get; set; }

    IStat CritChance { get; set; }

    IStat CritDamage { get; set; }
}