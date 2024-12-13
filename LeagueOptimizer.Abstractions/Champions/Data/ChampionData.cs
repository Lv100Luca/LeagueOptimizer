using System.Text.Json.Serialization;

namespace LeagueOptimizer.Abstractions.Champions.Data;

// add generic type for abilities
public class ChampionData<TChampionAbilityData>
{
    [JsonPropertyName("base_stats")]
    public required StatsData BaseStats { get; init; }
    public required TChampionAbilityData Abilities { get; init; }
}