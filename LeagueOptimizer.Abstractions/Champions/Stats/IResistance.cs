namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IResistance : IPerLevelStat
{
    public decimal FlatReduction { get; }
    public decimal PercentReduction { get; }

    // todo: pass IChampion
    public decimal DamageReduction(decimal bonusPen, decimal pen, decimal flatPen);
}