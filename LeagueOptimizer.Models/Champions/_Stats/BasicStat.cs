using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions._Stats;

public class BasicStat(decimal baseValue = 0m) : IBasicStat
{
    public decimal Base { get; set; } = baseValue;
    public decimal Bonus { get; set; }
    public decimal Total => Base + Bonus;
}