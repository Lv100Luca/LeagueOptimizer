using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

public class AttackSpeed(AttackSpeedData data) : IStat
{
    public AttackSpeed(AttackSpeedData data, Level level) : this(data)
    {
        _level = level;
    }

    private Level _level;

    public decimal Base => data.Base; // todo: check this
    public decimal Bonus { get; set; }

    public decimal Total => StatsCalculator.CalculateTotalAttackSpeed(
        _level, data.Base, data.Growth, Bonus, data.Ratio);

    public void UpdateLevel(Level level)
    {
        _level = level;
    }
}