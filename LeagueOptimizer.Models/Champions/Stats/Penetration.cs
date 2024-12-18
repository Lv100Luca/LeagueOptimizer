using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class Penetration : IPenetration
{
    public decimal Flat { get; set; }
    public decimal Percent { get; set; }
    public decimal PercentBonus { get; set; }
}