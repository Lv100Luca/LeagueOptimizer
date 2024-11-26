using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

public class Resistance(StatData statData) : IResistance
{
    private Level _level;

    public decimal Base => StatsCalculator.CalculatePerLevelBaseStat(_level, statData.Base, statData.Growth);
    public decimal Bonus { get; set; }
    public decimal Total => Base + Bonus; // todo: factor in reduction

    public void UpdateLevel(Level level)
    {
        _level = level;
    }

    public decimal FlatReduction { get; set; }
    public decimal PercentReduction { get; set; }

    public decimal DamageReduction(decimal bonusPen, decimal pen, decimal flatPen)
    {
        throw new NotImplementedException();
    }
}