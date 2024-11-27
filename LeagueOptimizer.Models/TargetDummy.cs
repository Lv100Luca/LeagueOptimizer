using LeagueOptimizer.Abstractions;

namespace LeagueOptimizer.Models;

public class TargetDummy : ITarget
{
    public decimal BaseHp { get; init; }
    public decimal BonusHp { get; set; }
    public decimal MaxHp => BaseHp + BonusHp;

    public decimal CurrentHpPercentage { get; set; }
    public decimal CurrentHp => CurrentHpPercentage * MaxHp;
    public decimal MissingHp => MaxHp - CurrentHp;

    public decimal BaseArmor { get; set; }
    public decimal BonusArmor { get; set; }
    public decimal TotalArmor => BaseArmor + BonusArmor;

    public decimal FlatArmorReduction { get; set; }
    public decimal ArmorReduction { get; set; }

    public decimal BaseMagicResist { get; set; }
    public decimal BonusMagicResist { get; set; }
    public decimal TotalMagicResist => BaseMagicResist + BonusMagicResist;

    public decimal FlatMagicResistReduction { get; set; }
    public decimal MagicResistReduction { get; set; }
}