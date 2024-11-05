using Level = LeagueOptimizer.Abstractions.Champions.Level;

namespace LeagueOptimizer.Abstractions.Stats;

public interface IPerLevelStat : IStat
{
    // formula and value can be found here:
    // https://leagueoflegends.fandom.com/wiki/Champion_statistic under #Increasing Statistics
    public const decimal SchizoPerLevelMultiplier1 = 0.7025m;
    public const decimal SchizoPerLevelMultiplier2 = 0.0175m;

    public decimal BaseAt(Level level)
    {
        var g = Growth;
        var n = level.Value;

        return g * (n - 1) * (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1));
    }

    /// <summary>
    /// The per level value of the stat
    /// </summary>
    public decimal Growth { get; set; }

    new public decimal Total(Level level)
        => Base + Bonus + BaseAt(level);
}