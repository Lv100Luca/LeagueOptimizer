namespace LeagueOptimizer.Models.ChampionStats;

public class Stats
{
    public Health Health { get; set; }
    public HealthRegen HealthRegen { get; set; }
    public AttackDamage AttackDamage { get; set; }
    public AttackSpeed AttackSpeed { get; set; }
    public Armor Armor { get; set; }
    public MagicResist MagicResist { get; set; }
    public int AttackRange { get; set; }
    public int MovementSpeed { get; set; }

    override public string ToString()
    {
        return $"Stats:\n" +
               $"  Health: {Health.Base}(+{Health.Bonus})\n";
    }
    // override public string ToString()
    // {
    //     return $"Stats:\n" +
    //            $"  Health: {Health.Base}(+{Health.Bonus})\n" +
    //            $"  Health Regen: {HealthRegen.Base}(+{HealthRegen.Bonus})\n" +
    //            $"  Attack Damage: {AttackDamage.Base}(+{AttackDamage.Bonus})\n" +
    //            $"  Attack Speed: {AttackSpeed.Base}(+{AttackSpeed.Bonus})\n" +
    //            $"  Armor: {Armor.Base}(+{Armor.Bonus})\n" +
    //            $"  Magic Resist: {MagicResist.Base}(+{MagicResist.Bonus})\n" +
    //            $"  Attack Range: {AttackRange}\n" +
    //            $"  Movement Speed: {MovementSpeed}";
    // }
}