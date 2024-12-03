namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IResistance : IStat
{
    public decimal FlatReduction { get; set; }
    public decimal PercentReduction { get; set; }
}