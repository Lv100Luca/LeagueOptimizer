using LeagueOptimizer.Models.ChampionStats;
using Level = LeagueOptimizer.Abstractions.Champions.Level;

namespace LeagueOptimizer.Abstractions.Stats;

public interface IPerLevelStat : IStat
{
    public double BaseAt(Level level)
    {
        return Base + Growth * level.Value;
    }

    /// <summary>
    /// The per level value of the stat
    /// </summary>
    // [JsonPropertyName("growth")]
    public double Growth { get; set; }
}