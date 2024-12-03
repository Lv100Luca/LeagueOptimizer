using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models;

public class TargetDummy : ITarget
{
    public required IStats Stats { get; set; }
}