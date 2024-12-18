using LeagueOptimizer.Abstractions;
using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Models.Calculations;

namespace LeagueOptimizer.Services;

public class DamageCalculator
{
    public DamageResult CalculateDamage(
        IChampion champion,
        ITarget target,
        List<Func<ITarget, DamageResult>> abilitySequence
    )
    {
        var totalDamage = 0m;

        foreach (var ability in abilitySequence)
        {
            // todo: i hate this but it wortk
            /*
             * find an elegant way to do this
             * - clone the target somehow
             * -
             */
            var armor = CalculateTargetResistance(champion, target, DamageType.Physical);
            var mr = CalculateTargetResistance(champion, target, DamageType.Magic);

            var rawAbilityDamage = ability(target);

            Console.Out.WriteLine("=================");
            Console.Out.WriteLine($"Target HP:          {target.Health.Current:F2}");
            Console.Out.WriteLine($"Target Armor:       {armor:F2}");
            Console.Out.WriteLine($"Raw Ability Damage: {rawAbilityDamage.Damage:F2}");

            var damageMultiplier = rawAbilityDamage.DamageType switch
            {
                DamageType.Physical => ResistanceFormula(armor),
                DamageType.Magic => ResistanceFormula(mr),
                DamageType.True => 1,
                _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
            };


            var damageTaken =
                rawAbilityDamage.Damage * damageMultiplier;

            totalDamage += damageTaken;

            Console.Out.WriteLine($"Damage Multiplier:  {damageMultiplier:P}");
            Console.Out.WriteLine($"Damage Taken:       {damageTaken:F2}");
            target.Health.Current -= damageTaken;
        }

        return new DamageResult(DamageType.Physical, totalDamage);
    }

    public decimal CalculateResistanceDamageReduction(IChampion champion, ITarget target, DamageType damageType)
    {
        return ResistanceFormula(CalculateTargetResistance(champion, target, damageType));
    }

    public decimal ResistanceFormula(decimal resistance)
    {
        return 1 - (100m / (100m + resistance));
    }

    public decimal CalculateTargetResistance(IChampion champion, ITarget target, DamageType damageType)
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

            // Console.Out.WriteLine(
                // $"Armor after flat reduction: ({baseResistance:F1}/{bonusResistance:F1}) {totalResistance:F1}");
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