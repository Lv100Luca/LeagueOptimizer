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
    private decimal _bonus;

    // AttackSpeed per level adds to the bonus value but shouldnt be factored in when setting
    // todo: add wiki entry for this
    public decimal Bonus
    {
        get => _bonus + StatsCalculator.CalculatePerLevelBonusAttackSpeed(_level, data.Growth);
        set => _bonus = value;
    }

    public decimal Total => StatsCalculator.CalculateTotalAttackSpeed(
        data.Base, Bonus, data.Ratio);

    public void UpdateLevel(Level level)
    {
        _level = level;
    }
}