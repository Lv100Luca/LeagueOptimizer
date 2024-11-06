namespace LeagueOptimizer.Abstractions;

public interface ICriticalDamageResult : IDamageResult
{
    decimal AverageDamage { get; set; }
    decimal CriticalDamage { get; set; }
}