using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class Resistance(Level level, StatData data) : IResistance
{
    public decimal FlatReduction { get; set; } = 0m;
    public decimal PercentReduction { get; set; } = 0m;

    public decimal Base { get; private set; } = Formulas.CalculatePerLevelBaseStat(level, data.Base, data.Growth);

    private decimal Growth { get; set; } = data.Growth;

    public decimal Bonus { get; set; } = 0m;

    public Resistance(StatData data) : this(Level.Default, data)
    {
    }

    public decimal Total => Base + Bonus;

    public void Update(Level level)
    {
        Base = Formulas.CalculatePerLevelBaseStat(level, Base, Growth);
    }
}