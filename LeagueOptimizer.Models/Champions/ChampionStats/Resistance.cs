using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

public class Resistance(IStat stat) : IResistance
{
    public decimal Base { get; set; } = stat.Base;
    public decimal Bonus { get; set; } = stat.Bonus;
    public decimal Total => Base + Bonus; // todo: factor in reduction

    public decimal FlatReduction { get; set; }
    public decimal PercentReduction { get; set; }
}