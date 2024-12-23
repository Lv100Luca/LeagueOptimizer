namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IResource : IStat
{
    public decimal Max => Total;
    public decimal Current { get; set; }
    public decimal Missing => Max - Current;
}