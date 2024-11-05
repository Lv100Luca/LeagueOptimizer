using LeagueOptimizer.Abstractions.Champions.Data;

namespace LeagueOptimizer.Abstractions.Stats;

public class PerLevelStat(decimal baseValue, decimal growth) : IPerLevelStat
{
    public decimal Base { get; set; } = baseValue;
    public decimal Growth { get; set; } = growth;
    public decimal Bonus { get; set; } = 0;
    public decimal Total { get; set; } = 0;

    public PerLevelStat(StatData data) : this(data.Base, data.Growth){}
}