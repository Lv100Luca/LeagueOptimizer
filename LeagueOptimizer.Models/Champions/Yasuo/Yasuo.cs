using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Models.Calculations;
using LeagueOptimizer.Models.Champions._Stats;
using LeagueOptimizer.Models.Champions.Yasuo.AbilityData;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions.Yasuo;

public class Yasuo(ChampionData<YasuoAbilityData> data, ILogger<Champion> logger) : Champion(data.BaseStats, logger)
{
    public const string FilePath = "Champions/Yasuo/Yasuo.json";

    override public string Name { get; } = "Yasuo";

    public YasuoAbilityData AbilitiesData { get; init; } = data.Abilities;

    // champion specific flags


    private decimal CalculateExcessCritBonusAD()
    {
        if (CritChance.Total < MaxCritChance)
            return 0;

        return CritChance.Total - MaxCritChance * 0.5m;
    }

    // formula 125 + (475 + 17 x (level - 1) x (0.7025 + 0.0175 x (level - 1)))
    private decimal CalculatePassiveShield()
    {
        return 125 + (475 + 17 * (Level.Value - 1) * (Formulas.SchizoPerLevelMultiplier1 + Formulas.SchizoPerLevelMultiplier2 * (Level.Value - 1)));
    }

    // this applies for normal attacks
    private decimal CriticalStrikeDamageMultiplier { get; set; } = 0.9m;

    public CriticalDamageResult CalculateNormalAttackDamage()
    {
        // consider non crit, crit and average damage
        const decimal normalAttackScaling = 1.0m;

        var dmg = AttackDamage.Total * normalAttackScaling;

        return new CriticalDamageResult(DamageType.Physical, dmg, CritChance.Total,
            CritDamage.Total * CriticalStrikeDamageMultiplier);
    }
}