namespace LeagueOptimizer.Abstractions.Stats;

public interface IStat
{
    /// <summary>
    /// The base value of the stat
    /// </summary>
    public double Base { get; set; }

    /// <summary>
    /// The bonus value of the stat
    /// </summary>
    public double Bonus { get; set; }

    // todo make function or property
    /// <summary>
    /// The total value of the stat
    /// </summary>
    public double Total => Base + Bonus;
}