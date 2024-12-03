using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Models.Champions.ChampionStats;

public class Stats : IStats
{
    public required IResource Health { get; set; }
    public required IResource Resource { get; set; }
    public required IStat AttackDamage { get; set; }
    public required IAttackSpeed AttackSpeed { get; set; }
    public required IResistance Armor { get; set; }
    public required IResistance MagicResist { get; set; }
    public required IBasicStat AttackRange { get; set; }
    public required IBasicStat MovementSpeed { get; set; }

    public IBasicStat AbilityPower { get; set; } = new BasicStat(0);
    public IPenetration ArmorPen { get; set; } = new Penetration();
    public IPenetration MagicPen { get; set; } = new Penetration();
    public IBasicStat AbilityHaste { get; set; } = new BasicStat(0);
    public IBasicStat Lifesteal { get; set; } = new BasicStat(0);
    public IBasicStat CritChance { get; set; } = new BasicStat(0);
    public IBasicStat CritDamage { get; set; } = new BasicStat(1.75m);
}