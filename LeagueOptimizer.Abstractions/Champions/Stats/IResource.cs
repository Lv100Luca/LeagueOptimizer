namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IResource : IStat
{
    public decimal CurrentResourcePercentage { get; set; }
    public decimal CurrentResource { get; }
    public decimal MissingResource { get; }

    public IStat Regen { get; set; }
}