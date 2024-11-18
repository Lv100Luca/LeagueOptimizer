using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Models.Champions.Caitlyn.AbilityData;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions.Caitlyn;

public class Caitlyn(ChampionData<CaitlynAbilityData> data, ILogger<Caitlyn> logger) : Champion(data.BaseStats, logger)
{
    public const string FilePath = "Champions/Caitlyn/Caitlyn.json";

    override public string Name { get; set; } = "Caitlyn";

    public CaitlynAbilityData AbilitiesData { get; init; } = data.Abilities;

    // todo move to Champion.cs
    public CriticalDamageResult CalculateNormalAttackDamage()
    {
        // consider non crit, crit and average damage
        const decimal normalAttackScaling = 1.0m;

        var dmg = TotalAttackDamage * normalAttackScaling;

        return new CriticalDamageResult(DamageType.Physical, dmg, this);
    }

    public string AbilitiesToString()
    {
        return $"\nAbilities:\n" +
               $"  Passive:\n" +
               $"    Champion Base Damage: {string.Join(", ", AbilitiesData.Passive.ChampionBaseDmg)}\n" +
               $"    Base Damage:          {string.Join(", ", AbilitiesData.Passive.BaseDmg)}\n" +
               $"    Crit Scaling:         {AbilitiesData.Passive.CritScaling:P}\n" +
               $"    IE Crit Scaling:      {AbilitiesData.Passive.IeCritScaling:P}\n" +
               $"  Spell Q:\n" +
               $"    Cost:                 {string.Join(", ", AbilitiesData.SpellQ.Cost)}\n" +
               $"    Cooldown:             {string.Join(", ", AbilitiesData.SpellQ.Cooldown)}\n" +
               $"    Base Damage:          {string.Join(", ", AbilitiesData.SpellQ.BaseDmg)}\n" +
               $"    AD Scaling:           {string.Join(", ", AbilitiesData.SpellQ.TotalAdScaling)}\n" +
               $"    Reduced Damage Multiplier: {AbilitiesData.SpellQ.ReducedDamageMultiplier:P}\n" +
               $"  Spell W:\n" +
               $"    Cost:                 {AbilitiesData.SpellW.Cost}\n" +
               $"    Cooldown:             {AbilitiesData.SpellW.Cooldown:F1}\n" +
               $"    Recharge:             {string.Join(", ", AbilitiesData.SpellW.Recharge)}\n" +
               $"    Duration:             {string.Join(", ", AbilitiesData.SpellW.Duration)}\n" +
               $"    Maximum Charges:      {string.Join(", ", AbilitiesData.SpellW.MaximumCharges)}\n" +
               $"    Base Damage:          {string.Join(", ", AbilitiesData.SpellW.BaseDmg)}\n" +
               $"    Bonus AD Scaling:     {AbilitiesData.SpellW.BonusAdScaling:P}\n" +
               $"  Spell E:\n" +
               $"    Cost:                 {AbilitiesData.SpellE.Cost}\n" +
               $"    Cooldown:             {string.Join(", ", AbilitiesData.SpellE.Cooldown)}\n" +
               $"    Base Damage:          {string.Join(", ", AbilitiesData.SpellE.BaseDmg)}\n" +
               $"    AP Scaling:           {AbilitiesData.SpellE.ApScaling:P}\n" +
               $"    Slow Amount:          {AbilitiesData.SpellE.SlowAmount:P}\n" +
               $"    Slow Duration:        {AbilitiesData.SpellE.SlowDuration:F1}s\n" +
               $"  Spell R:\n" +
               $"    Cost:                 {AbilitiesData.SpellR.Cost}\n" +
               $"    Cooldown:             {AbilitiesData.SpellR.Cooldown}s\n" +
               $"    Base Damage:          {string.Join(", ", AbilitiesData.SpellR.BaseDmg)}\n" +
               $"    Bonus AD Scaling:     {AbilitiesData.SpellR.BonusAdScaling:P}\n" +
               $"    Crit Scaling:         {AbilitiesData.SpellR.CritScaling:P}\n";
    }
}