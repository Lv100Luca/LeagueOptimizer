namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IStats
{
    public IResource Health { get; set; }
    public IResource Resource { get; set; }

    public IStat AttackDamage { get; set; }
    public IAttackSpeed AttackSpeed { get; set; }

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