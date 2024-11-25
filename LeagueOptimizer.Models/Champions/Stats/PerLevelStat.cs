using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

/// <summary>
/// Represents a stat that is based on the champion's level.
/// </summary>
public abstract class PerLevelStat(StatData statData) : Stat, IPerLevelStat
{
    public Level Level { get; set; } = Level.Default;

    override public decimal Base => CalculatePerLevelStat(StartingValue, Growth);

    public decimal StartingValue { get; set; } = statData.Base;
    public decimal Growth { get; set; } = statData.Growth;

    private const decimal SchizoPerLevelMultiplier1 = 0.7025m;
    private const decimal SchizoPerLevelMultiplier2 = 0.0175m;

    private decimal CalculatePerLevelStat(decimal baseValue, decimal growth)
    {
        // formula and value can be found here:
        // https://leagueoflegends.fandom.com/wiki/Champion_statistic under #Increasing Statistics

        var g = growth;
        var n = Level.Value;

        return baseValue + (g * (n - 1) * (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1)));
    }

    public void UpdateLevel(Level level)
    {
        Level = level;
    }
}