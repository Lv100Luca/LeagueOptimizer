namespace LeagueOptimizer.Models.ChampionStats;

public interface IStat
{
    /// <summary>
    /// The base value of the stat
    /// </summary>
    // [JsonPropertyName("base")]
    public double Base { get; set; }

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