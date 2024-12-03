namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IBasicStat
{
    decimal Base { get; set; }
    decimal Bonus { get; set; }
    decimal Total { get; }
}