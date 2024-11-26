namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IAttackSpeed : IPerLevelStat
{
    public decimal Ratio { get; init; }
}