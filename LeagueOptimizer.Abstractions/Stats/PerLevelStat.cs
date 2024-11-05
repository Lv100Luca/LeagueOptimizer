using LeagueOptimizer.Abstractions.Champions.Data;

namespace LeagueOptimizer.Abstractions.Stats;

public class PerLevelStat(double baseValue, double growth) : IPerLevelStat
{
    public double Base { get; set; } = baseValue;
    public double Growth { get; set; } = growth;
    public double Bonus { get; set; } = 0;
    public double Total { get; set; } = 0;

    public PerLevelStat(StatData data) : this(data.Base, data.Growth){}
}