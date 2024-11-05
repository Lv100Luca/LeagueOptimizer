using LeagueOptimizer.Models.ChampionStats;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LeagueOptimizer.Services;
// todo add interface
public class StatReader (ILogger<StatReader> logger)
{
    // LeagueOptimizer.Models/Champions/Caitlyn/Caitlyn.json
    public Stats? ReadStats(string path)
    {
        using var reader = File.OpenText(path);

        var jsonString = reader.ReadToEnd();
        var jsonReader = new JsonTextReader(new StringReader(jsonString));
        return JsonSerializer.Deserialize<Stats>(jsonReader);

    }
}