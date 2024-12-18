﻿using System.Text.Json;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Services;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Services;

public class StatReader(ILogger<StatReader> logger) : IStatReader
{
    private readonly static JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
    };

    // LeagueOptimizer.Models/Champions/Caitlyn/Caitlyn.json
    public ChampionData<TChampionAbilityData> ReadStats<TChampionAbilityData>(string path)
    {
        using var reader = File.OpenText(path);

        var jsonString = reader.ReadToEnd();

        if (string.IsNullOrEmpty(jsonString))
            throw new FileNotFoundException("File not found", path);

        var result = JsonSerializer.Deserialize<ChampionData<TChampionAbilityData>>(jsonString, JsonSerializerOptions);

        if (result == null)
            throw new JsonException("Failed to deserialize");

        return result;
    }
}