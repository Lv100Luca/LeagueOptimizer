using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

public class Penetration : IPenetration
{
    public decimal FlatPen { get; set; } = 0m;
    public decimal PercentPen { get; set; } = 0m;
    public decimal PercentBonusPen { get; set; } = 0m;
}