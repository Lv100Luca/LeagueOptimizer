using LeagueOptimizer.Abstractions.Champions.Data;

namespace LeagueOptimizer.Models.Champions.Stats;

public class AttackSpeed(StatData statData) : PerLevelStat(statData)
{
    override public decimal Base { get; set; }

    private decimal Ratio { get; set; }

    public AttackSpeed(StatData statData, decimal ratio) : this(statData)
    {
        Ratio = ratio;
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