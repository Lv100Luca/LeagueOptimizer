using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

/// <summary>
/// Represents a simple stat with a base value and a bonus value.
/// </summary>
public class Stat : IStat
{
    public Stat(Level level, StatData statData)
    {
        Base = Formulas.CalculatePerLevelBaseStat(level, statData.Base, statData.Growth);
        Growth = statData.Growth;
        Bonus = 0m;
    }

    public Stat(StatData statData) : this(Level.Default, statData)
    {
    }

    public decimal Base { get; private set; }

    private decimal Growth { get; set; }

    public decimal Bonus { get; set; }

    public decimal Total => Base + Bonus;

    public void Update(Level level)
    {
        Base = Formulas.CalculatePerLevelBaseStat(level, Base, Growth);
    }
}