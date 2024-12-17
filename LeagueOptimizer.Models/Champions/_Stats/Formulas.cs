using LeagueOptimizer.Abstractions.Champions;

namespace LeagueOptimizer.Models.Champions.Stats;

public static class Formulas
{
    private const decimal SchizoPerLevelMultiplier1 = 0.7025m;
    private const decimal SchizoPerLevelMultiplier2 = 0.0175m;

    public static decimal CalculatePerLevelBonusAttackSpeed(Level level, decimal growth)
    {
        var g = growth;
        var n = level.Value;

        return g * (n - 1) * (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1));
    }

    public static decimal CalculateTotalAttackSpeed(
        decimal startingValue,
        decimal bonus,
        decimal ratio)
    {
        return startingValue + ratio * bonus;
    }

    public static decimal CalculatePerLevelBaseStat(Level level, decimal baseValue, decimal growth)
    {
        var g = growth;
        var n = level.Value;

        return baseValue + (g * (n - 1) * (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1)));
    }
}