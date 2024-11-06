using LeagueOptimizer.Abstractions.Champions.Data;

namespace LeagueOptimizer.Abstractions.Stats;

public class Stat(decimal baseValue) : IStat
{
    public decimal Base { get; set; } = baseValue;
    public decimal Bonus { get; set; } = 0;

    public Stat(StatData data) : this(data.Base){}
}