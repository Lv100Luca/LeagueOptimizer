using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Services;
using LeagueOptimizer.Models.Champions.Caitlyn;
using LeagueOptimizer.Models.Champions.Caitlyn.AbilityData;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Services;

public class ChampionFactory(StatReader statReader, ILogger<ChampionFactory> logger) : IChampionFactory
{
    public IChampion Build(ChampionNames championName)
    {
        return championName switch
        {
            ChampionNames.Caitlyn => new Caitlyn(statReader.ReadStats<CaitlynAbilityData>(Caitlyn.FilePath), new Logger<Caitlyn>(new LoggerFactory())),
            _ => throw new NotImplementedException()
        };
    }
}