namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IPenetration
{
    /// <summary>
    /// The flat penetration of the attack
    /// </summary>
    public decimal FlatPen{ get; set; }

    /// <summary>
    /// The percent penetration of the attack
    /// </summary>
    public decimal PercentPen { get; set; }

    /// <summary>
    /// The percent bonus penetration of the attack
    /// <remarks>
    /// Only applies to bonus resistances
    /// </remarks>
    /// </summary>
    public decimal PercentBonusPen { get; set; }
}