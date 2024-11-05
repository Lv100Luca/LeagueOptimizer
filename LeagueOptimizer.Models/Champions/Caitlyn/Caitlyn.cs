using LeagueOptimizer.Abstractions.Champions.Data;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions.Caitlyn;

public class Caitlyn(ChampionData data, ILogger<Caitlyn> logger) : Champion(data, logger)
{
    public const string FilePath = "Champions/Caitlyn/Caitlyn.json";

    override public string Name { get; set; } = "Caitlyn";
}