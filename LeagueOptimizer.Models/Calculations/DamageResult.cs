using LeagueOptimizer.Abstractions;

namespace LeagueOptimizer.Models.Calculations;

public class DamageResult(DamageType damageType, decimal damage)
{
    public DamageType DamageType { get; set; } = damageType;
    public decimal Damage { get; set; } = damage;

    override public string ToString()
    {
        return $"{DamageType}: {Damage}";
    }
}