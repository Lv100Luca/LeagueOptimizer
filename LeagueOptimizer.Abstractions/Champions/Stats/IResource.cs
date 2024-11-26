namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IResource : IPerLevelStat
{
    public ResourceType ResourceType { get; }

    public decimal CurrentResourcePercentage { get; }
    public decimal CurrentResource { get; }
    public decimal MissingResource { get; }
}