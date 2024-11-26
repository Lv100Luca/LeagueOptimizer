using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats.Resources;

public class Resource(StatData statData, StatData regenData, ResourceType resourceType) : PerLevelStat(statData), IResource
{
    public ResourceType ResourceType => resourceType;

    public ResourceRegen Regen { get; set; } = new(regenData);

    public decimal CurrentResourcePercentage { get; set; } = 1m;

    public decimal CurrentResource => CurrentResourcePercentage * Total;
    public decimal MissingResource => Total - CurrentResource;
}