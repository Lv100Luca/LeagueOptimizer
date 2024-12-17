using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Stats;
using LeagueOptimizer.Models.Champions._Stats;

namespace LeagueOptimizer.Models;

public class TargetDummy : ITarget
{
    public IResource Health { get; set; }
    public IResistance Armor { get; set; }
    public IResistance MagicResist { get; set; }

    public TargetDummy(decimal health, decimal armor, decimal magicResist)
    {
        Health = new Resource(health);
        Health.Current = health;
        Armor = new Resistance(armor);
        MagicResist = new Resistance(magicResist);
    }

    public TargetDummy(decimal health, decimal armor, decimal magicResist, decimal currentHealthPercent = 100)
    {
        Health = new Resource(health);
        Health.Current = health * currentHealthPercent / 100;
        Armor = new Resistance(armor);
        MagicResist = new Resistance(magicResist);
    }

    public TargetDummy()
    {

    }
}