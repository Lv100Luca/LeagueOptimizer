using System.Text.Json.Serialization;

namespace LeagueOptimizer.Abstractions.Champions.Data;

public class ChampionData
{
    [JsonPropertyName("base_stats")]
    public StatsData BaseStatsData { get; set; }
    public object Abilities { get; set; }
}