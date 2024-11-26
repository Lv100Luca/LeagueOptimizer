using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class Penetration : IPenetration
{
    public decimal FlatPen { get; set; }
    public decimal PercentPen { get; set; }
    public decimal PercentBonusPen { get; set; }
}