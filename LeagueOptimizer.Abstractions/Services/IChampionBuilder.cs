using LeagueOptimizer.Abstractions.Champions;
namespace LeagueOptimizer.Abstractions.Services;

public interface IChampionFactory {
    Champion Build(ChampionNames championName);
}
