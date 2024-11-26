using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

/// <summary>
/// Represents a simple stat with a base value and a bonus value.
/// </summary>
public class Stat(StatData statData) : IStat
{
    public Stat(StatData statData, Level level) : this(statData)
    {
        _level = level;
    }

    private Level _level;

    public decimal Base => StatsCalculator.CalculatePerLevelBaseStat(_level, statData.Base, statData.Growth);
    public decimal Bonus { get; set; } = 0m;
    public decimal Total => Base + Bonus;

    public void UpdateLevel(Level level)
    {
        _level = level;
    }
}