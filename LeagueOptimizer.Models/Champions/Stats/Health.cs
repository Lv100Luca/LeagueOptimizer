using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Models.Champions.Stats.Resources;

namespace LeagueOptimizer.Models.Champions.Stats;

/// <summary>
/// The health of a champion
/// </summary>
public class Health(StatData statData, StatData regenData) : Resource(statData, regenData, ResourceType.Health)
{
}