namespace LeagueOptimizer.Abstractions;

public class DamageResult(DamageType damageType, decimal damage)
{
    public DamageType DamageType { get; set; } = damageType;
    public decimal Damage { get; set; } = damage;
}