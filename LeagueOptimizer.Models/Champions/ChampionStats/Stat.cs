using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

/// <summary>
/// Represents a simple stat with a base value and a bonus value.
/// </summary>
public class Stat(decimal baseValue) : IStat
{
    public decimal Base { get; set; } = baseValue;
    public decimal Bonus { get; set; } = 0m;
    public decimal Total => Base + Bonus;
}