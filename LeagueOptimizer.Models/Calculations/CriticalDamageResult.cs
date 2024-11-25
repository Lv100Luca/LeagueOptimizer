using System.Text;
using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Models.Champions;

namespace LeagueOptimizer.Models.Calculations;

public class CriticalDamageResult : DamageResult
{
    /// <summary>
    /// The average damage of the attack
    /// </summary>
    /// <remarks>
    /// Factors in crit chance
    /// </remarks>
    public decimal AverageDamage { get; set; }

    /// <summary>
    /// The critical damage of the attack
    /// </summary>
    public decimal CriticalDamage { get; set; }

    public CriticalDamageResult(DamageType damageType, decimal damage, decimal critChance, decimal critDamageMultiplier, decimal nonCritBonusDamage = 0)
        : base(damageType, damage + nonCritBonusDamage)
    {
        // Average damage multiplier = 1 + (Critical chance × (0.75 + Bonus critical damage))
        CriticalDamage = critDamageMultiplier * damage + nonCritBonusDamage;
        // todo think about - 1 workaround
        var multiplier = 1m + critChance * (critDamageMultiplier - 1);
        AverageDamage = damage * multiplier + nonCritBonusDamage;
    }

    public CriticalDamageResult(DamageType damageType, decimal damage, Champion champion, decimal nonCritBonusDamage = 0) : this(damageType, damage,
        champion.CritChance, champion.CritDamage, nonCritBonusDamage)
    {
    }

    override public string ToString()
    {
        return new StringBuilder()
            .AppendLine($"Damage Type: {DamageType}")
            .AppendLine($"Base Damage: {Damage}")
            .AppendLine($"Average Damage: {AverageDamage}")
            .AppendLine($"Critical Damage: {CriticalDamage}")
            .ToString();
    }
}