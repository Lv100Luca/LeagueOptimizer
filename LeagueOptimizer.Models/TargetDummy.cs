using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models;

public class TargetDummy : ITarget
{
    public required IResource Health { get; set; }
    public required IResistance Armor { get; set; }
    public required IResistance MagicResist { get; set; }
}