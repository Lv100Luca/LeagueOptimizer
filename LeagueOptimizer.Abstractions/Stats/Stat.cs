using LeagueOptimizer.Abstractions.Champions.Data;

namespace LeagueOptimizer.Abstractions.Stats;

public class Stat(double baseValue) : IStat
{
    public double Base { get; set; } = baseValue;
    public double Bonus { get; set; } = 0;
    public double Total { get; set; } = baseValue;

    public Stat(StatData data) : this(data.Base){}
}