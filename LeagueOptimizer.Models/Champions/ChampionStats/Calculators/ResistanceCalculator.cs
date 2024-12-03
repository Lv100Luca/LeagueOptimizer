// using LeagueOptimizer.Abstractions;
// using LeagueOptimizer.Abstractions.Champions;
// using LeagueOptimizer.Abstractions.Champions.Stats;
//
// namespace LeagueOptimizer.Models.Champions.ChampionStats.Calculators;
//
// public static class ResistanceCalculator
// {
//     // temporary members
//     // public static decimal CalculateResistanceDamageReduction(ITarget target, DamageType damageType)
//     // {
//         // return 100m / (100m + CalculateTargetResistance(target, damageType));
//     // }
//
//     // public static decimal CalculateTargetResistance(ITarget target, DamageType damageType)
//     // {
//     //     return damageType switch
//     //     {
//     //         DamageType.Physical => CalculateTargetResistance(target.FlatArmorReduction, target.ArmorReduction,
//     //             target.BaseArmor, target.BonusArmor,
//     //             target.TotalArmor, ArmorPen.PercentBonusPen, ArmorPen.PercentPen, ArmorPen.FlatPen),
//     //         DamageType.Magic => CalculateTargetResistance(target.FlatMagicResistReduction, target.MagicResistReduction,
//     //             target.BaseMagicResist, target.BonusMagicResist,
//     //             target.TotalMagicResist, MagicPen.PercentBonusPen, MagicPen.FlatPen, 0),
//     //         _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
//     //     };
//     // }
//
//     public static decimal CalculateTargetArmor(ITarget target, IChampion champion)
//     {
//         return CalculateTargetResistance(target.Armor, champion.ArmorPen);
//     }
//
//     public static decimal CalculateTargetMagicResist(ITarget target, IChampion champion)
//     {
//         return CalculateTargetResistance(target.MagicResist, champion.MagicPen);
//     }
//
//     public static decimal CalculateTargetResistance(IResistance resistance, IPenetration penetration)
//     {
//         // todo create generic method for both armor and mr
//         /* todo keep in mind that:
//          Armor Reduction REDUCES the armor
//          Penetration just ignores the armor
//          */
//
//         // Armor Reduction
//         // Flat armor reduction
//
//         var totalResistance = resistance.Total;
//         var baseResistance = resistance.Base;
//         var bonusResistance = resistance.Bonus;
//
//         if (resistance.FlatReduction > 0)
//         {
//             var tmpTotal = resistance.Total - resistance.FlatReduction;
//             var flatReductionscalingFactor = tmpTotal / resistance.Total;
//
//             baseResistance *= flatReductionscalingFactor;
//             bonusResistance *= flatReductionscalingFactor;
//
//             totalResistance = baseResistance + bonusResistance;
//
//             if (totalResistance < 0)
//             {
//                 Console.Out.WriteLine($"Armor({totalResistance:F1}) is lower than 0, exiting");
//
//                 return totalResistance;
//             }
//
//             Console.Out.WriteLine(
//                 $"Armor after flat reduction: ({baseResistance:F1}/{bonusResistance:F1}) {totalResistance:F1}");
//         }
//
//
//         // percent reduction
//         if (resistance.PercentReduction > 0)
//         {
//             var percentReductionScalingFactor = 1 - resistance.PercentReduction;
//             baseResistance *= percentReductionScalingFactor;
//             bonusResistance *= percentReductionScalingFactor;
//
//             totalResistance = baseResistance + bonusResistance;
//
//             Console.Out.WriteLine(
//                 $"Armor after percent reduction: ({baseResistance:F1}/{bonusResistance:F1}) {totalResistance:F1}");
//         }
//
//         var totalArmor = totalResistance;
//
//         // Percent Bonus Armor Pen
//         if (penetration.PercentBonusPen > 0)
//         {
//             var percentBonusArmorPenScalingFactor = 1 - penetration.PercentBonusPen;
//
//             totalArmor = baseResistance + (bonusResistance * percentBonusArmorPenScalingFactor);
//
//             Console.Out.WriteLine($"Armor after percent bonus pen: {totalArmor:F1}");
//         }
//
//         //Percent Armor Pen
//         // todo how does total and bonus armor pen work together?
//         if (penetration.PercentPen > 0)
//         {
//             var percentArmorPenScalingFactor = 1 - penetration.PercentPen;
//
//             totalArmor *= percentArmorPenScalingFactor;
//
//             Console.Out.WriteLine($"Armor after percent armor pen: {totalArmor:F1}");
//         }
//
//         // Flat Armor Pen
//         if (penetration.FlatPen > 0)
//         {
//             totalArmor -= penetration.FlatPen;
//
//             Console.Out.WriteLine($"Armor after flat armor pen: {totalArmor:F1}");
//         }
//
//         return totalArmor;
//     }
// }