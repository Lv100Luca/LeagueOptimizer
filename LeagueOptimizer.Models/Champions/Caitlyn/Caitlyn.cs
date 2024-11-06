using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions.Data;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions.Caitlyn;

public class Caitlyn(ChampionData data, ILogger<Caitlyn> logger) : Champion(data, logger)
{
    public const string FilePath = "Champions/Caitlyn/Caitlyn.json";

    override public string Name { get; set; } = "Caitlyn";

    // todo move to Champion.cs
    public CriticalDamageResult CalculateNormalAttackDamage()
    {
        // consider non crit, crit and average damage
        const decimal normalAttackScaling = 1.0m;

        var dmg = AttackDamage.Total(Level) * normalAttackScaling;

        return new CriticalDamageResult(DamageType.Physical, dmg, this);
    }
}