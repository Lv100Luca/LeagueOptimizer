using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Abstractions;

public interface ITarget
{
    IStats Stats { get; set; }
}