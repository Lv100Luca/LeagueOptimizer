using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

public class Resource(StatData resourceData, StatData regenData)
    : IResource
{
    private Level _level;

    public decimal Base => StatsCalculator.CalculatePerLevelBaseStat(_level, resourceData.Base, resourceData.Growth);
    public decimal Bonus { get; set; }
    public decimal Total => Base + Bonus;

    public void UpdateLevel(Level level)
    {
        _level = level;
    }

    public decimal CurrentResourcePercentage { get; set; } = 1m;
    public decimal CurrentResource => CurrentResourcePercentage * Total;
    public decimal MissingResource => Total - CurrentResource;

    public IStat Regen { get; set; } = new Stat(regenData);
}