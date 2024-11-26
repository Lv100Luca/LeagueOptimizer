using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Abstractions.Champions;

public interface IChampion
{
    public abstract string Name { get; set; }
    public Level Level { get; set; }

    public IResource Health { get; set; }
    public IResource Resource { get; set; }

}