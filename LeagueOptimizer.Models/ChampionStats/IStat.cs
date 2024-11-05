namespace LeagueOptimizer.Models.ChampionStats;

public interface IStat
{
    /// <summary>
    /// The total value of the stat
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// The base value of the stat
    /// </summary>
    public int Base { get; set; }

    /// <summary>
    /// The bonus value of the stat
    /// </summary>
    public int Bonus { get; set; }

    /// <summary>
    /// The per level value of the stat
    /// </summary>
    public int Growth { get; set; }
}