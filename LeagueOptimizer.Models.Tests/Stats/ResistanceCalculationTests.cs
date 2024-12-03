// using LeagueOptimizer.Abstractions;
// using LeagueOptimizer.Abstractions.Champions;
// using Moq;
//
// namespace LeagueOptimizer.Models.Tests.Stats;
//
// public class ResistanceCalculationTests
// {
//     [Test]
//     public void TestArmorCalculation1()
//     {
//         const decimal flatPen = 10;
//         const decimal percentBonusPen = 0.45m;
//
//         const decimal targetBaseArmor = 100;
//         const decimal targetBonusArmor = 200;
//
//         const decimal targetFlatArmorReduction = 30;
//         const decimal targetPercentArmorReduction = 0.3m;
//
//         var target = new Mock<ITarget>();
//         target.Setup(x => x.BaseArmor).Returns(targetBaseArmor);
//         target.Setup(x => x.BonusArmor).Returns(targetBonusArmor);
//         target.Setup(x => x.FlatArmorReduction).Returns(targetFlatArmorReduction);
//         target.Setup(x => x.ArmorReduction).Returns(targetPercentArmorReduction);
//
//         var champion = new Mock<IChampion>();
//         champion.Setup(x => x.ArmorPen.FlatPen).Returns(flatPen);
//         champion.Setup(x => x.ArmorPen.PercentBonusPen).Returns(percentBonusPen);
//
//     }
// }