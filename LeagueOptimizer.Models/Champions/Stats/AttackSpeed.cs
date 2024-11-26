using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class AttackSpeed(AttackSpeedData statData) : PerLevelStat(statData), IAttackSpeed
{
    override public decimal Base { get; set; }

    public decimal Ratio { get; init; }

    public AttackSpeed(AttackSpeedData statData, Level level) : this(statData)
    {
        Ratio = statData.Ratio;
        Level = level;
    }

    private decimal CalculateAttackSpeed()
    {
        // formula and value can be found here:
        // https://leagueoflegends.fandom.com/wiki/Champion_statistic under #Increasing Statistics

        var g = Growth;
        var n = Level.Value;

        return StartingValue + (Bonus + g * (n - 1) *
            (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1))) * Ratio;
    }

    override public decimal Total =>
        CalculateAttackSpeed();
}