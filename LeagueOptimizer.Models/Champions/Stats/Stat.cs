using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

/// <summary>
/// Represents a simple stat with a base value and a bonus value.
/// </summary>
public class Stat(Level level, StatData statData) : IStat
{
    public Stat(StatData statData) : this(Level.Default, statData)
    {
    }

    public decimal Base { get; private set; } = Formulas.CalculatePerLevelBaseStat(level, statData.Base, statData.Growth);

    private decimal Growth { get; set; } = statData.Growth;

    public decimal Bonus { get; set; } = 0m;

    public decimal Total => Base + Bonus;

    public void Update(Level level)
    {
        Base = Formulas.CalculatePerLevelBaseStat(level, Base, Growth);
    }
}