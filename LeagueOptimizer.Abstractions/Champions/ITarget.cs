using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Abstractions.Champions;

public interface ITarget
{
    public IResource Health { get; set; }

    public IResistance Armor { get; set; }

    public IResistance MagicResist { get; set; }
}