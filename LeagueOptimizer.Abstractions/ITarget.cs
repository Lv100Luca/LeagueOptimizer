namespace LeagueOptimizer.Abstractions;

public interface ITarget
{
    public decimal BaseHp { get; }
    public decimal BonusHp { get; set; }
    public decimal MaxHp { get; }

    public decimal CurrentHpPercentage { get; set; }
    public decimal CurrentHp { get; }
    public decimal MissingHp { get; }

    public decimal BaseArmor { get; set; }
    public decimal BonusArmor { get; set; }
    public decimal TotalArmor { get; }

    public decimal FlatArmorReduction { get; set; }
    public decimal ArmorReduction { get; set; }

    public decimal BaseMagicResist { get; set; }
    public decimal BonusMagicResist { get; set; }
    public decimal TotalMagicResist { get; }

    public decimal FlatMagicResistReduction { get; set; }
    public decimal MagicResistReduction { get; set; }
}