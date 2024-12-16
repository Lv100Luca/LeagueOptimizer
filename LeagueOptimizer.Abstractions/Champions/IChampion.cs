using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Abstractions.Champions;

public interface IChampion : ITarget
{
    public string Name { get; set; }

    public Level Level { get; set; }

    // stats
    public IResource Resource { get; set; }
    public IStat AttackDamage { get; set; }
    public IAttackSpeed AttackSpeed { get; set; }
    public IPenetration ArmorPen { get; set; }
    public IPenetration MagicPen { get; set; }
    public IBasicStat AttackRange { get; set; }
    public IBasicStat MovementSpeed { get; set; }

    // abilities
    public IBasicStat Ap { get; set; }
    public decimal AbilityHaste { get; set; }
    public decimal Lifesteal { get; set; }
    public IBasicStat CritChance { get; set; }
    public IBasicStat CritDamage { get; set; }
}