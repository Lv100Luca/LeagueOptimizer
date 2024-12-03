namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IStat
{
    public decimal Base { get; set; }
    public decimal Bonus { get; set; }

    public decimal Total => Base + Bonus;
}