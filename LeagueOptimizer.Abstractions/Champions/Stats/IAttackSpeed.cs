namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IAttackSpeed : IStat
{
    new public decimal Base { get; set; }
    new public decimal Bonus { get; set; }
    new public decimal Total { get; }
}