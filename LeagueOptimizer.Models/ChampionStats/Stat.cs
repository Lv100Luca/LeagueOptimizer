using LeagueOptimizer.Models.Champions;

namespace LeagueOptimizer.Models.ChampionStats;

public abstract class Stat
{
    /// <summary>
    /// The base value of the stat
    /// </summary>
    // [JsonPropertyName("base")]
    public double Base { get; set; }

    public double BaseAt(Level level)
    {
        return Base + Growth * level.Value;
    }

    /// <summary>
    /// The per level value of the stat
    /// </summary>
    // [JsonPropertyName("growth")]
    public double Growth { get; set; }

    /// <summary>
    /// The total value of the stat
    /// </summary>
    // [JsonPropertyName("total")]
    public double Total { get; set; }

    /// <summary>
    /// The bonus value of the stat
    /// </summary>
    // [JsonPropertyName("bonus")]
    public double Bonus { get; set; }
}