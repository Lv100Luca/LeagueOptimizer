namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IPerLevelStat : IStat
{
    public Level Level { get; }

    public decimal StartingValue { get; }
    public decimal Growth { get; }
}