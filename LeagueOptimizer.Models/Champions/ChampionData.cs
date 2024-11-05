using LeagueOptimizer.Models.ChampionStats;

namespace LeagueOptimizer.Models.Champions;

public class ChampionData
{
    public object Details { get; set; }
    public Stats BaseStats { get; set; }
    public object Abilities { get; set; }
}