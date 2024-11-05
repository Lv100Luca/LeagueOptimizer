namespace LeagueOptimizer.Abstractions.Champions.Data;

public class StatsData
{
    public required StatData Health { get; set; }
    public required StatData HealthRegen { get; set; }
    public required StatData Resource { get; set; }
    public required StatData ResourceRegen { get; set; }
    public required StatData AttackDamage { get; set; }
    public required AttackSpeedData AttackSpeed { get; set; }
    public required StatData Armor { get; set; }
    public required StatData MagicResist { get; set; }
    public required double AttackRange { get; set; }
    public required double MovementSpeed { get; set; }

    override public string ToString()
    {
        return $"Stats:\n" +
               $"  Health:          {Health.Base} (+{Health.Growth})\n" +
               $"  Health Regen:    {HealthRegen.Base} (+{HealthRegen.Growth})\n" +
               $"  Attack Damage:   {AttackDamage.Base} (+{AttackDamage.Growth})\n" +
               $"  Attack Speed:    {AttackSpeed.Base} (+{AttackSpeed.Growth})\n" +
               $"  Armor:           {Armor.Base} (+{Armor.Growth})\n" +
               $"  Magic Resist:    {MagicResist.Base} (+{MagicResist.Growth})\n" +
               $"  Attack Range:    {AttackRange}\n" +
               $"  Movement Speed:  {MovementSpeed}";
    }
}
