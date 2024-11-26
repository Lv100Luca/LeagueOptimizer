namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IPerLevelStat : IStat
{
    public decimal StartingValue { get; }
    public decimal Growth { get; }

    public void UpdateLevel(Level level);
}