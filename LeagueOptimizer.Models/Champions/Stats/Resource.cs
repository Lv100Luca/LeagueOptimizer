using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class Resource : IResource
{
    public decimal Base { get; private set; }

    private decimal Growth { get; set; }

    public decimal Bonus { get; set; }
    public decimal Total => Base + Bonus;

    public Resource(Level level, StatData resourceData, StatData regenData)
    {
        Base = Formulas.CalculatePerLevelBaseStat(level, resourceData.Base, resourceData.Growth);
        Growth = resourceData.Growth;
        Bonus = 0m;
        Regen = new Stat(level, regenData);
    }

    public Resource(StatData resourceData, StatData regenData) : this(Level.Default, resourceData, regenData)
    {
    }

    public void Update(Level level)
    {
        Base = Formulas.CalculatePerLevelBaseStat(level, Base, Growth);
    }

    public decimal CurrentResourcePercentage { get; set; } = 1m;
    public decimal CurrentResource => CurrentResourcePercentage * Total;
    public decimal MissingResource => Total - CurrentResource;

    public IStat Regen { get; set; }
}