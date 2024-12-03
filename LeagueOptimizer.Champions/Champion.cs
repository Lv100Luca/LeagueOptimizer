using System.Text;
using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Abstractions.Champions.Stats;
using LeagueOptimizer.Models.Champions.ChampionStats;
using LeagueOptimizer.Services;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions;

public abstract class Champion : IChampion
{
    private readonly ILogger<Champion> logger;

    // todo: add method for calculating normal attack dmg
    // todo: figure out if items set stats or stats will be calculated from items
    protected Champion(StatsData data, ILogger<Champion> logger)
    {
        this.logger = logger;

        StatsData = data;

        Level = Level.Default;
    }

    public abstract string Name { get; set; }

    private Level _level = Level.Default;
    public StatsData StatsData { get; set; }

    public Level Level
    {
        get => _level;
        set
        {
            _level = value;
            Stats = StatsCalculator.UpdateStats(this);
        }
    }

    // todo: calculate with service
    public IStats Stats { get; set; }

    override public string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Champion: {Name}\n");
        sb.Append($"Level: {Level}\n");
        sb.Append($"Health: {Stats.Health.Total}\n");
        sb.Append($"Health Regen: {Stats.Health.Regen}\n");
        sb.Append($"Mana: {Stats.Resource.Total}\n");
        sb.Append($"Mana Regen: {Stats.Resource.Regen}\n");
        sb.Append($"Armor: {Stats.Armor.Total}\n");
        sb.Append($"Magic Resist: {Stats.MagicResist.Total}\n");
        sb.Append($"Attack Damage: {Stats.AttackDamage.Total}\n");
        sb.Append($"Attack Speed: {Stats.AttackSpeed.Total}\n");
        sb.Append($"Attack Range: {Stats.AttackRange}\n");
        sb.Append($"Movement Speed: {Stats.MovementSpeed}\n");
        sb.Append($"Ability Power: {Stats.AbilityPower.Total}\n");
        sb.Append($"Ability Haste: {Stats.AbilityHaste}\n");
        sb.Append($"Lifesteal: {Stats.Lifesteal:P}\n");
        sb.Append($"Crit Chance: {Stats.CritChance:P}\n");
        sb.Append($"Crit Damage: {Stats.CritDamage:P}\n");

        return sb.ToString();
    }
}