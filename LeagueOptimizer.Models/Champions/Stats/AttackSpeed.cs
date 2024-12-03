using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class AttackSpeed(Level level, AttackSpeedData statData) : IAttackSpeed
{
    public decimal Base { get; set; } = statData.Base;

    private decimal Growth { get; set; } = statData.Growth;
    private decimal Ratio { get; set; } = statData.Ratio;
    private decimal _perLevelBonus = Formulas.CalculatePerLevelBonusAttackSpeed(level, statData.Growth);

    public AttackSpeed(AttackSpeedData statData) : this(Level.Default, statData)
    {
    }

    // AttackSpeed per level adds to the bonus value but shouldnt be factored in when setting
    // todo: add wiki entry for this
    private decimal _bonus = 0m;

    public decimal Bonus
    {
        get => _perLevelBonus + _bonus;
        set => _bonus = value;
    }

    public decimal Total =>
        Formulas.CalculateTotalAttackSpeed(Base, Bonus, Ratio);

    public void Update(Level level)
    {
        _perLevelBonus = Formulas.CalculatePerLevelBonusAttackSpeed(level, Growth);
    }
}