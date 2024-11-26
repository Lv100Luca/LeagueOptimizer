using LeagueOptimizer.Abstractions.Champions.Stats;

namespace LeagueOptimizer.Abstractions.Champions;

public interface IChampion
{
    public abstract string Name { get; set; }
    public Level Level { get; set; }

    public IResource Health { get; set; }
    public IResource Resource { get; set; }

    public IStat AttackDamage { get; set; }
    public IStat AttackSpeed { get; set; }

    public IResistance Armor { get; set; }
    public IResistance MagicResist { get; set; }

    public IBasicStat AttackRange { get; set; }
    public IBasicStat MovementSpeed { get; set; }

    public IBasicStat AbilityPower { get; set; }

    public IPenetration ArmorPen { get; set; }
    public IPenetration MagicPen { get; set; }

    public IBasicStat AbilityHaste { get; set; }
    public IBasicStat Lifesteal { get; set; }

    public IBasicStat CritChance { get; set; }
    public IBasicStat CritDamage { get; set; }
}