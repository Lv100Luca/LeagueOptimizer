using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Abstractions.Champions;

public interface IChampion : ITarget
{
    public StatsData StatsData { get; set; }

    public Level Level { get; set; }
    public IStats Stats { get; }
}