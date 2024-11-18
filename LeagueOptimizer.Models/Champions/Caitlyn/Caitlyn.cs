using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Models.Champions.Caitlyn.AbilityData;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions.Caitlyn;

public class Caitlyn(ChampionData<CaitlynAbilityData> data, ILogger<Caitlyn> logger) : Champion(data.BaseStats, logger)
{
    public const string FilePath = "Champions/Caitlyn/Caitlyn.json";

    override public string Name { get; set; } = "Caitlyn";

    public CaitlynAbilityData AbilitiesData { get; init; } = data.Abilities;

    // todo move to Champion.cs
    public CriticalDamageResult CalculateNormalAttackDamage()
    {
        // consider non crit, crit and average damage
        const decimal normalAttackScaling = 1.0m;

        var dmg = TotalAttackDamage * normalAttackScaling;

        return new CriticalDamageResult(DamageType.Physical, dmg,this);
    }
}