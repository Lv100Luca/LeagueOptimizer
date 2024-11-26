using LeagueOptimizer.Abstractions.Champions;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

public static class StatsCalculator
{
    private const decimal SchizoPerLevelMultiplier1 = 0.7025m;
    private const decimal SchizoPerLevelMultiplier2 = 0.0175m;

    public static decimal CalculateTotalAttackSpeed(
        Level level,
        decimal startingValue,
        decimal growth,
        decimal bonus,
        decimal ratio)
    {
        var g = growth;
        var n = level.Value;

        return startingValue + (bonus + g * (n - 1) *
            (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1))) * ratio;
    }

    public static decimal CalculatePerLevelBaseStat(Level level, decimal baseValue, decimal growth)
    {
        var g = growth;
        var n = level.Value;

        return baseValue + (g * (n - 1) * (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1)));
    }
}