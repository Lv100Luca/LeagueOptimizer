namespace LeagueOptimizer.Abstractions.Stats;

// todo prob obsolete
public interface IStat
{
    /// <summary>
    /// The base value of the stat
    /// </summary>
    public decimal Base { get; set; }

    /// <summary>
    /// The bonus value of the stat
    /// </summary>
    public decimal Bonus { get; set; }

    // todo make function or property
    /// <summary>
    /// The total value of the stat
    /// </summary>
    public decimal Total => Base + Bonus;
}