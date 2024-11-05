using LeagueOptimizer.Abstractions.Champions;

namespace LeagueOptimizer.Abstractions.Services;

public interface IChampionFactory
{
    IChampion Build(ChampionNames championName);
}
