using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.Stats;

public class Resource(Level level, StatData resourceData, StatData regenData) : IResource
{
    public decimal Base { get; private set; } =
        Formulas.CalculatePerLevelBaseStat(level, resourceData.Base, resourceData.Growth);

    private decimal StartValue { get; set; } = resourceData.Base;
    private decimal Growth { get; set; } = resourceData.Growth;

    public decimal Bonus { get; set; } = 0m;
    public decimal Total => Base + Bonus;

    public Resource(StatData resourceData, StatData regenData) : this(Level.Default, resourceData, regenData)
    {
    }

    public void Update(Level level)
    {
        Base = Formulas.CalculatePerLevelBaseStat(level, StartValue, Growth);
    }

    public decimal CurrentResourcePercentage { get; set; } = 1m;
    public decimal CurrentResource => CurrentResourcePercentage * Total;
    public decimal MissingResource => Total - CurrentResource;

    public IStat Regen { get; set; } = new Stat(level, regenData);
}