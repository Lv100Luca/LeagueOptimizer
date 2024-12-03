namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IAttackSpeed : IStat
{
    public decimal Base { get; set; }
    public decimal Bonus { get; set; }
    public decimal PerLevelBonus { get; set; }
    public decimal Total { get; set; }
}