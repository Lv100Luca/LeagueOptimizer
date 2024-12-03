using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class AttackSpeed : IAttackSpeed
{
    public decimal Base { get; set; }

    private decimal Growth { get; set; }
    private decimal Ratio { get; set; }
    private decimal _perLevelBonus = 0m;

    public AttackSpeed(Level level, AttackSpeedData statData)
    {
        Base = statData.Base;
        Growth = statData.Growth;
        Bonus = 0m;
        Ratio = statData.Ratio;
        _perLevelBonus = Formulas.CalculatePerLevelBonusAttackSpeed(level, statData.Growth);
    }

    public AttackSpeed(AttackSpeedData statData) : this(Level.Default, statData)
    {
    }

    // AttackSpeed per level adds to the bonus value but shouldnt be factored in when setting
    // todo: add wiki entry for this
    private decimal _bonus;

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