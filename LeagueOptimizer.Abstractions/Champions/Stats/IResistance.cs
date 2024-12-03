namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IResistance : IStat
{
    public decimal FlatReduction { get; }
    public decimal PercentReduction { get; }
}