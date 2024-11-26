using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

/// <summary>
/// Represents a stat that is based on the champion's level.
/// </summary>
public class PerLevelStat(StatData statData) : IPerLevelStat
{
    public PerLevelStat(StatData statData, Level level) : this(statData)
    {
        Level = level;
    }

    public decimal Base => CalculatePerLevelStat(StartingValue, Growth);
    public decimal Bonus { get; set; }

    public decimal Multiplier { get; set; }

    public decimal Total => CalculatePerLevelStat(Base, Growth);

    private Level Level { get; set; } = Level.Default;


    public decimal StartingValue { get; set; } = statData.Base;
    public decimal Growth { get; set; } = statData.Growth;

    protected const decimal SchizoPerLevelMultiplier1 = 0.7025m;
    protected const decimal SchizoPerLevelMultiplier2 = 0.0175m;

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