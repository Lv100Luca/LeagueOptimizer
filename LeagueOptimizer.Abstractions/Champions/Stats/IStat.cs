namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IStat
{
    public decimal Base { get; }
    public decimal Bonus { get; set; }

    public decimal Total { get; }

    public void Update(Level level);
}