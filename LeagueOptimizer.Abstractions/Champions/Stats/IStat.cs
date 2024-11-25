namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IStat
{
    public decimal Base { get; }
    public decimal Bonus { get; }

    public decimal Multiplier { get; }

    public decimal Total();
}