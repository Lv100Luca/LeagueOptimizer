namespace LeagueOptimizer.Abstractions;

public interface IDamageResult
{
    DamageType DamageType { get; set; }
    decimal Damage { get; set; }
}