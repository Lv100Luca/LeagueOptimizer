using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;
using LeagueOptimizer.Models.Champions.ChampionStats;

namespace LeagueOptimizer.Services;

public static class StatsCalculator
{
    private const decimal SchizoPerLevelMultiplier1 = 0.7025m;
    private const decimal SchizoPerLevelMultiplier2 = 0.0175m;

    private static decimal CalculateTotalAttackSpeed(
        decimal startingValue,
        decimal bonus,
        decimal ratio)
    {
        return startingValue + ratio * bonus;
    }

    internal static decimal CalculatePerLevelBonusAttackSpeed(Level level, decimal growth)
    {
        var g = growth;
        var n = level.Value;

        return g * (n - 1) * (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1));
    }

    internal static decimal CalculatePerLevelBaseStat(Level level, decimal baseValue, decimal growth)
    {
        var g = growth;
        var n = level.Value;

        return baseValue + (g * (n - 1) * (SchizoPerLevelMultiplier1 + SchizoPerLevelMultiplier2 * (n - 1)));
    }

    public static IStats UpdateStats(IChampion champion)
    {
        var stats = champion.Stats;
        var data = champion.StatsData;

        stats.Health.Base =
            CalculatePerLevelBaseStat(champion.Level, data.Health.Base, data.Health.Growth);

        stats.Resource.Base = CalculatePerLevelBaseStat(champion.Level, data.Resource.Base,
            data.Resource.Growth);

        stats.AttackDamage.Base = CalculatePerLevelBaseStat(champion.Level, data.AttackDamage.Base,
            data.AttackDamage.Growth);

        stats.AttackSpeed.PerLevelBonus =
            CalculatePerLevelBonusAttackSpeed(champion.Level, data.AttackSpeed.Growth);

        stats.AttackSpeed.Total = CalculateTotalAttackSpeed(data.AttackSpeed.Base, champion.Stats.AttackSpeed.Bonus, data.AttackSpeed.Ratio);

        stats.Armor.Base = CalculatePerLevelBaseStat(champion.Level, data.Armor.Base,
            data.Armor.Growth);

        stats.MagicResist.Base = CalculatePerLevelBaseStat(champion.Level, data.MagicResist.Base,
            data.MagicResist.Growth);

        return stats;
    }
}