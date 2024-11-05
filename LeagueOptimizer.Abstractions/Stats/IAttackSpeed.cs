using LeagueOptimizer.Abstractions.Champions;

namespace LeagueOptimizer.Abstractions.Stats;

public class AttackSpeed : IPerLevelStat
{
    public double Base { get; set; }
    public double Bonus { get; set; }
    public double Growth { get; set; }
    public double Ratio { get; set; }

    public AttackSpeed(double baseValue, double growth, double ratio)
    {
        Base = baseValue;
        Bonus = 0;
        Growth = growth;
        Ratio = ratio;
    }

    public double Total(Level level)
    {
        var g = Growth;
        var n = level.Value;

        Console.Out.WriteLine("Base: " + Base);
        Console.Out.WriteLine("Bonus: " + Bonus);
        Console.Out.WriteLine("Growth: " + Growth);
        Console.Out.WriteLine("Ratio: " + Ratio);
        // formula as string with values:
        Console.Out.WriteLine($"{Base} + ({Bonus} + {g} * ({n} - 1) * ({IPerLevelStat.SchizoPerLevelMultiplier1} + {IPerLevelStat.SchizoPerLevelMultiplier2} * ({n} - 1))) * {Ratio}");
        return Base + (Bonus + g * (n - 1) * (IPerLevelStat.SchizoPerLevelMultiplier1 + IPerLevelStat.SchizoPerLevelMultiplier2 * (n - 1))) * Ratio;
    }
}