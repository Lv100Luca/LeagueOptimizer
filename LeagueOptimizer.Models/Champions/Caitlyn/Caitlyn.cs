using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Models.Calculations;
using LeagueOptimizer.Models.Champions.Caitlyn.AbilityData;
using Microsoft.Extensions.Logging;

namespace LeagueOptimizer.Models.Champions.Caitlyn;

public class Caitlyn(ChampionData<CaitlynAbilityData> data, ILogger<Caitlyn> logger) : Champion(data.BaseStats, logger)
{
    public const string FilePath = "Champions/Caitlyn/Caitlyn.json";

    override public string Name { get; } = "Caitlyn";

    public CaitlynAbilityData AbilitiesData { get; init; } = data.Abilities;

    // champion specific flags
    public bool HasHeadshotActive { get; set; } = false;

    public bool TargetIsTrapped { get; set; } = false;

    public bool TargetIsChampion { get; set; } = true;

    public CriticalDamageResult CalculateNormalAttackDamage()
    {
        // consider non crit, crit and average damage
        const decimal normalAttackScaling = 1.0m;

        var dmg = AttackDamage.Total * normalAttackScaling;

        var headshotBonusDamage = CalculateHeadshotBonusDamage();

        return new CriticalDamageResult(DamageType.Physical, dmg, this, headshotBonusDamage);
    }

    public bool IsPrimaryQTarget { get; set; } = true;

    public DamageResult CalculateQSpellDamage()
    {
        var AbilityLevel = 5; // todo implement for champions

        var qBaseDamage = AbilitiesData.SpellQ.BaseDmg[AbilityLevel - 1];

        var qAdScaling = AbilitiesData.SpellQ.TotalAdScaling[AbilityLevel - 1];

        var qDamage = qBaseDamage + qAdScaling * AttackDamage.Bonus;

        if (IsPrimaryQTarget)
            qDamage *= AbilitiesData.SpellQ.ReducedDamageMultiplier;

        return new DamageResult(DamageType.Physical, qDamage);
    }

    public DamageResult CalculateSpellEDamage()
    {
        var AbilityLevel = 5;

        var eBaseDamage = AbilitiesData.SpellE.BaseDmg[AbilityLevel - 1];

        var eApScaling = AbilitiesData.SpellE.ApScaling;

        return new DamageResult(DamageType.Magic, eBaseDamage * eApScaling);
    }

    public DamageResult CalculateSpellRDamage()
    {
        var AbilityLevel = 3;

        var rBaseDamage = AbilitiesData.SpellR.BaseDmg[AbilityLevel - 1];

        var rBonusAdScaling = AbilitiesData.SpellR.BonusAdScaling;

        var rCritChanceDamageMultiplier = 1 + AbilitiesData.SpellR.CritScaling * CritChance.Total;

        Console.Out.WriteLine("rCritChanceDamageMultiplier: " + rCritChanceDamageMultiplier);

        var rDamage = rBaseDamage * rBonusAdScaling * rCritChanceDamageMultiplier;

        return new DamageResult(DamageType.Physical, rDamage);
    }

    [Obsolete("placeholder until items are implemented")]
    public bool HasIE { get; set; } = true;

    private decimal CalculateHeadshotBonusDamage()
    {
        if (!HasHeadshotActive && !TargetIsTrapped)
            return 0;

        var scalingIndex = Math.Clamp((Level.Value - 1) / 6, 0, 2);

        var baseHeadshotScaling = TargetIsChampion
            ? AbilitiesData.Passive.ChampionTotalAdScaling[scalingIndex]
            : AbilitiesData.Passive.TotalAdScaling[scalingIndex];

        // todo figure out if this is how this works
        // crit scaling plus additional scaling when HasIE is true
        var critHeadshotScaling =
            (AbilitiesData.Passive.CritScaling + (HasIE ? AbilitiesData.Passive.IeCritBonusScaling : 0)) * CritChance.Total;

        var headshotScaling = baseHeadshotScaling + critHeadshotScaling;

        var headshotDamage = headshotScaling * AttackDamage.Total;

        if (TargetIsTrapped)
            headshotDamage += CalculateEnemyTrappedBonusDamage();

        return headshotDamage;
    }

    private decimal CalculateEnemyTrappedBonusDamage()
    {
        var AbilityLevel = 5; // todo implement for champions

        var trapBaseDamage = AbilitiesData.SpellW.BaseDmg[AbilityLevel - 1];

        return trapBaseDamage + (AbilitiesData.SpellW.BonusAdScaling * AttackDamage.Bonus);
    }
    public DamageResult CalculateTestAbilityDamage(ITarget target)
    {
        var bonusAdScaling = 1m;

        var percentMaxHpDamage = 0.5m;

        // var abilityBaseDamage = AttackDamage.Bonus * bonusAdScaling + 200;

        // Console.Out.WriteLine("Base damage: " + abilityBaseDamage);

        var currentHpDamage = target.Health.Current * percentMaxHpDamage;

        target.Armor.FlatReduction += 10;

        // Console.Out.WriteLine("Target Max HP: " + target.Health.Max);
        // Console.Out.WriteLine("%: "+ currentHpDamage);

        // var totalDamage = abilityBaseDamage + maxHpDamage;

        return new DamageResult(DamageType.Physical, currentHpDamage);
    }

    public DamageResult Calculate1000Damage(ITarget target)
    {
        return new DamageResult(DamageType.Physical, 1000);
    }

    public string AbilitiesToString()
    {
        return $"\nAbilities:\n" +
               $"  Passive:\n" +
               $"    Champion Base Damage: {string.Join(", ", AbilitiesData.Passive.ChampionTotalAdScaling)}\n" +
               $"    Base Damage:          {string.Join(", ", AbilitiesData.Passive.TotalAdScaling)}\n" +
               $"    Crit Scaling:         {AbilitiesData.Passive.CritScaling:P}\n" +
               $"    IE Crit Scaling:      {AbilitiesData.Passive.IeCritBonusScaling:P}\n" +
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