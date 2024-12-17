using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class Resource(Level level, decimal startingValue, decimal growthValue = 0) : IResource
{
    public Resource(decimal baseValue, decimal bonusValue = 0) : this(Level.Default, baseValue)
    {
        Bonus = bonusValue;
    }

    public Resource(StatData resourceData) : this(Level.Default, resourceData.Base, resourceData.Growth)
    {
    }

    private decimal StartValue { get; set; } = startingValue;
    private decimal Growth { get; set; } = growthValue;

    public decimal Base { get; private set; } =
        Formulas.CalculatePerLevelBaseStat(level, startingValue, growthValue);

    public decimal Bonus { get; set; } = 0m;
    public decimal Total => Base + Bonus;
    public decimal Current { get; set; }

    public void Update(Level level)
    {
        Base = Formulas.CalculatePerLevelBaseStat(level, StartValue, Growth);
    }
}