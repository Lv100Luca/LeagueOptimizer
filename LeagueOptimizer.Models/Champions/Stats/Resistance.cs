using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class Resistance(StatData statData) : PerLevelStat(statData), IResistance
{
    public decimal FlatReduction { get; set; }
    public decimal PercentReduction { get; set; }

    public decimal DamageReduction(decimal bonusPen, decimal pen, decimal flatPen)
    {
        throw new NotImplementedException();
    }
}