using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Stats;
using LeagueOptimizer.Models.Calculations;
using LeagueOptimizer.Models.Champions;

namespace LeagueOptimizer.Services;

public class DamageCalculator
{
    public DamageResult CalculateDamage(Champion champion,
        ITarget target,
        List<Func<ITarget, DamageResult>> abilitySequence)
    {
        var totalDamage = 0m;

        foreach (var ability in abilitySequence)
        {
            var test = ability(target);

            var targetResistance = CalculateTargetResistance(champion, target, test.DamageType);

            Console.Out.WriteLine($"Target Resistance: {targetResistance:N0}");
            Console.Out.WriteLine($"Resistance Multiplier: {1 - CalculateResistanceDamageReduction(champion, target, test.DamageType):F3}");

            totalDamage += test.Damage;

            target.Health.Current -= test.Damage;

            Console.Out.WriteLine(test);
        }

        return new DamageResult(DamageType.Physical, totalDamage);
    }

    public decimal CalculateResistanceDamageReduction(Champion champion, ITarget target, DamageType damageType)
    {
        return 100m / (100m + CalculateTargetResistance(champion, target, damageType));
    }

    public decimal CalculateTargetResistance(Champion champion, ITarget target, DamageType damageType)
    {
        return damageType switch
        {
            DamageType.Physical => CalculateTargetResistance(target.Armor.FlatReduction, target.Armor.PercentReduction,
                target.Armor.Base, target.Armor.Bonus,
                target.Armor.Total, champion.ArmorPen.PercentBonus, champion.ArmorPen.Percent, champion.ArmorPen.Flat),
            DamageType.Magic => CalculateTargetResistance(target.MagicResist.FlatReduction,
                target.MagicResist.PercentReduction,
                target.MagicResist.Base, target.MagicResist.Bonus,
                target.MagicResist.Total, champion.MagicPen.PercentBonus, champion.MagicPen.Percent, champion.MagicPen.Flat),
            DamageType.True => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
        };
    }

    public static decimal CalculateTargetResistance(
        decimal flatReduction,
        decimal percentReduction,
        decimal baseResistance,
        decimal bonusResistance,
        decimal totalResistance,
        decimal bonusPen,
        decimal percentPen,
        decimal lethality
    )
    {
        // todo create generic method for both armor and mr
        /* todo keep in mind that:
         Armor Reduction REDUCES the armor
         Penetration just ignores the armor
         */

        // Armor Reduction
        // Flat armor reduction
        if (flatReduction > 0)
        {
            var newTotal = totalResistance - flatReduction;
            var flatReductionscalingFactor = newTotal / totalResistance;

            baseResistance *= flatReductionscalingFactor;
            bonusResistance *= flatReductionscalingFactor;

            totalResistance = baseResistance + bonusResistance;

            if (totalResistance < 0)
            {
                Console.Out.WriteLine($"Armor({totalResistance:F1}) is lower than 0, exiting");

                return totalResistance;
            }

            Console.Out.WriteLine(
                $"Armor after flat reduction: ({baseResistance:F1}/{bonusResistance:F1}) {totalResistance:F1}");
        }


        // percent reduction
        if (percentReduction > 0)
        {
            var percentReductionScalingFactor = 1 - percentReduction;
            baseResistance *= percentReductionScalingFactor;
            bonusResistance *= percentReductionScalingFactor;

            totalResistance = baseResistance + bonusResistance;

            Console.Out.WriteLine(
                $"Armor after percent reduction: ({baseResistance:F1}/{bonusResistance:F1}) {totalResistance:F1}");
        }

        var totalArmor = totalResistance;

        // Percent Bonus Armor Pen
        if (bonusPen > 0)
        {
            var percentBonusArmorPenScalingFactor = 1 - bonusPen;

            totalArmor = baseResistance + (bonusResistance * percentBonusArmorPenScalingFactor);

            Console.Out.WriteLine($"Armor after percent bonus pen: {totalArmor:F1}");
        }

        //Percent Armor Pen
        // todo how does total and bonus armor pen work together?
        if (percentPen > 0)
        {
            var percentArmorPenScalingFactor = 1 - percentPen;

            totalArmor *= percentArmorPenScalingFactor;

            Console.Out.WriteLine($"Armor after percent armor pen: {totalArmor:F1}");
        }

        // Flat Armor Pen
        if (lethality > 0)
        {
            totalArmor -= lethality;

            Console.Out.WriteLine($"Armor after flat armor pen: {totalArmor:F1}");
        }

        return totalArmor;
    }
}