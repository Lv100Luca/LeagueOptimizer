using Level = LeagueOptimizer.Abstractions.Champions.Level;

namespace LeagueOptimizer.Abstractions.Stats;

public interface IPerLevelStat : IStat
{
    // formula and value can be found here:
    // https://leagueoflegends.fandom.com/wiki/Champion_statistic under #Increasing Statistics
    public const double SchizoPerLevelMultiplier1 = 0.7025;
    public const double SchizoPerLevelMultiplier2 = 0.0175;

    public double BaseAt(Level level)
    {
        var g = Growth;
        var n = level.Value;

        return g * (n - 1) * (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1));
    }

    /// <summary>
    /// The per level value of the stat
    /// </summary>
    public double Growth { get; set; }

    new public double Total(Level level)
        => Base + Bonus + BaseAt(level);
}