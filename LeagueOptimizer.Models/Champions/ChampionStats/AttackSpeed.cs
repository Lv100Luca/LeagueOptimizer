using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

public class AttackSpeed(decimal perLevelBonus) : IAttackSpeed
{
    public decimal Base { get; set; }

    // AttackSpeed per level adds to the bonus value but shouldnt be factored in when setting
    // todo: add wiki entry for this
    private decimal _bonus;

    public decimal Bonus
    {
        get => perLevelBonus + _bonus;
        set => _bonus = value;
    }

    public decimal PerLevelBonus { set; get; }

    public decimal Total { get; set; }
}