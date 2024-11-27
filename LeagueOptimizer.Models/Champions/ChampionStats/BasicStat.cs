using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

public class BasicStat(decimal baseValue) : IBasicStat
{
    public decimal Base { get; set; } = baseValue;
    public decimal Bonus { get; set; }
    public decimal Total => Base + Bonus;
}