using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

public class Resource
    : IResource
{
    public required decimal Base { get; set; }
    public decimal Bonus { get; set; } = 0m;
    public decimal Total => Base + Bonus;

    public decimal CurrentResourcePercentage { get; set; } = 1m;
    public decimal CurrentResource => CurrentResourcePercentage * Total;
    public decimal MissingResource => Total - CurrentResource;

    public required IStat Regen { get; set; }
}