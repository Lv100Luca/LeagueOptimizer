using LeagueOptimizer.Models.Champions;

namespace LeagueOptimizer.Models.ChampionStats.Resources.Mana;

public abstract class ManaChampion : Champion
{
    /// <summary>
    /// The Mana stat of the Champion
    /// </summary>
    Mana Mana { get; set; }

    /// <summary>
    /// The Mana Regen stat of the Champion
    /// </summary>
    ManaRegen ManaRegen { get; set; }
}