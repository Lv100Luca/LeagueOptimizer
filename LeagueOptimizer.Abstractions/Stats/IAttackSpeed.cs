using LeagueOptimizer.Abstractions.Champions;

namespace LeagueOptimizer.Abstractions.Stats;

public class AttackSpeed : IPerLevelStat
{
    public decimal Base { get; set; }
    public decimal Bonus { get; set; }
    public decimal Growth { get; set; }
    public decimal Ratio { get; set; }

    public AttackSpeed(decimal baseValue, decimal growth, decimal ratio)
    {
        Base = baseValue;
        Bonus = 0;
        Growth = growth;
        Ratio = ratio;
    }

    public decimal Total(Level level)
    {
        var g = Growth;
        var n = level.Value;

        return Base + (Bonus + g * (n - 1) * (IPerLevelStat.SchizoPerLevelMultiplier1 + IPerLevelStat.SchizoPerLevelMultiplier2 * (n - 1))) * Ratio;
    }
}