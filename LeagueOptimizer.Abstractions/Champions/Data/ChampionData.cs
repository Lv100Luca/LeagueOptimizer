using System.Text.Json.Serialization;

namespace LeagueOptimizer.Abstractions.Champions.Data;

// add generic type for abilities
public class ChampionData<TChampionAbilityData>
{
    [JsonPropertyName("base_stats")]
    public StatsData BaseStatsData { get; init; }
    public TChampionAbilityData Abilities { get; init; }
}