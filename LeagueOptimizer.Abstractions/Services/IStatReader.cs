using LeagueOptimizer.Abstractions.Champions.Data;

namespace LeagueOptimizer.Abstractions.Services;

public interface IStatReader
{
    ChampionData<TChampionAbilityData> ReadStats<TChampionAbilityData>(string path);
}