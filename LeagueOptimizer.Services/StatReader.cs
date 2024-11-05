using System.Text.Json;
using LeagueOptimizer.Models.Champions;
using LeagueOptimizer.Models.ChampionStats;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Services;

// todo add interface
public class StatReader(ILogger<StatReader> logger)
{
    private readonly static JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
    };

    // LeagueOptimizer.Models/Champions/Caitlyn/Caitlyn.json
    public ChampionData? ReadStats(string path)
    {
        using var reader = File.OpenText(path);

        var jsonString = reader.ReadToEnd();

        if (string.IsNullOrEmpty(jsonString))
        {
            logger.LogError("File is empty");

            return null;
        }

        return JsonSerializer.Deserialize<ChampionData>(jsonString, JsonSerializerOptions);
    }
}