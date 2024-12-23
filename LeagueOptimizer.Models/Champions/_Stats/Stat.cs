using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions._Stats;

/// <summary>
/// Represents a simple stat with a base value and a bonus value.
/// </summary>
public class Stat(Level level, decimal startingValue, decimal growthValue = 0) : IStat
{
    public Stat(decimal baseValue, decimal bonusValue = 0) : this(Level.Default, baseValue)
    {
        Bonus = bonusValue;
    }

    public Stat(StatData statData) : this(Level.Default, statData.Base, statData.Growth)
    {
    }

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