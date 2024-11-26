namespace LeagueOptimizer.Abstractions.Champions.Stats;

public interface IPenetration
{
    /// <summary>
    /// The flat penetration of the attack
    /// </summary>
    public decimal Flat{ get; }

    /// <summary>
    /// The percent penetration of the attack
    /// </summary>
    public decimal Percent { get; }

    /// <summary>
    /// The percent bonus penetration of the attack
    /// <remarks>
    /// Only applies to bonus resistances
    /// </remarks>
    /// </summary>
    public decimal PercentBonus { get; }
}