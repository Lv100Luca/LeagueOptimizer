using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

/// <summary>
/// Represents a simple stat with a base value and a bonus value.
/// </summary>
public abstract class Stat : IStat
{
    public virtual decimal Base { get; set; }
    public decimal Bonus { get; set; }

    public decimal Multiplier { get; set; }

    // todo: verify if this is correct
    public decimal Total()
    {
        var total = Base + Bonus;

        var multiplierBonus = total * Multiplier;

        return total + multiplierBonus;
    }
}