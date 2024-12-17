using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class Resistance(Level level, decimal startingValue, decimal growthValue = 0) : IResistance
{
    public Resistance(decimal baseValue, decimal bonusValue = 0) : this(Level.Default, baseValue)
    {
        Bonus = bonusValue;
    }

    public Resistance(StatData data) : this(Level.Default, data.Base, data.Growth)
    {
    }

    public decimal FlatReduction { get; set; } = 0m;
    public decimal PercentReduction { get; set; } = 0m;

    public decimal Base { get; private set; } = Formulas.CalculatePerLevelBaseStat(level, startingValue, growthValue);

    private decimal StartValue { get; set; } = startingValue;
    private decimal Growth { get; set; } = growthValue;

    public decimal Bonus { get; set; } = 0m;


    public decimal Total => Base + Bonus;

    public void Update(Level level)
    {
        Base = Formulas.CalculatePerLevelBaseStat(level, StartValue, Growth);
    }
}