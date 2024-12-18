using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions._Stats;

public class AttackSpeed(Level level, decimal baseValue, decimal growthValue = 0, decimal ratio = 0.625m) : IAttackSpeed
{
    public AttackSpeed(AttackSpeedData statData) : this(Level.Default, statData.Base, statData.Growth, statData.Ratio)
    {
    }

    private decimal Growth { get; set; } = growthValue;
    private decimal Ratio { get; set; } = ratio;
    private decimal _perLevelBonus = Formulas.CalculatePerLevelBonusAttackSpeed(level, growthValue);

    public decimal Base { get; set; } = baseValue;

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