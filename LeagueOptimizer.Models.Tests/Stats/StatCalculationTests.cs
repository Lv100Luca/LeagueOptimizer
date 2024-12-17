using LeagueOptimizer.Abstractions.Champions;
using LeagueOptimizer.Abstractions.Champions.Data;
using LeagueOptimizer.Models.Champions._Stats;

namespace LeagueOptimizer.Models.Tests.Stats;

public class StatCalculationTests
{
    // this test uses example stats from caitlyn
    [TestCase(1, 580)]
    [TestCase(2, 657.04)]
    [TestCase(3, 737.83)]
    [TestCase(4, 822.36)]
    [TestCase(5, 910.63)]
    [TestCase(6, 1002.65)]
    [TestCase(7, 1098.42)]
    [TestCase(8, 1197.93)]
    [TestCase(9, 1301.18)]
    [TestCase(10, 1408.18)]
    [TestCase(11, 1518.93)]
    [TestCase(12, 1633.42)]
    [TestCase(13, 1751.65)]
    [TestCase(14, 1873.63)]
    [TestCase(15, 1999.36)]
    [TestCase(16, 2128.82)]
    [TestCase(17, 2262.04)]
    [TestCase(18, 2399)]
    public void TestPerLevelStatCalculation(int level, decimal expectedValue)
    {
        const decimal baseValue = 580;
        const decimal growth = 107;

        var perLevelStat = new Stat(Level.From(level), baseValue, growth);

        Assert.That(perLevelStat.Total, Is.EqualTo(expectedValue).Within(0.1m));
    }

    // this test uses the example stats from Alistar
    [Test]
    public void TestPerLevelStatCalculationAlistar()
    {
        const decimal baseValue = 685;
        const decimal growth = 120;
        var level = Level.From(2);

        const decimal expectedValue = 771.4m;

        var perLevelStat = new Stat(level, baseValue, growth);

        Assert.That(perLevelStat.Total, Is.EqualTo(expectedValue).Within(0.1m));
    }


    // this test uses the example given on the wiki using Volibear
    [Test]
    public void TestAttackSpeedCalculationVolibear()
    {
        const decimal baseValue = 0.625m;
        const decimal growth = 0.02m;
        const decimal ratio = 0.7m;
        const decimal bonusAttackSpeed = 0.25m;

        var level = Level.From(3);

        var attackSpeed = new AttackSpeed(level, baseValue, growth, ratio) { Bonus = bonusAttackSpeed };

        const decimal expectedValue = 0.82065m;

        Assert.That(attackSpeed.Total, Is.EqualTo(expectedValue).Within(0.001m));
    }

    [Test]
    public void TestStatCalculationWithBonus()
    {
        const decimal baseValue = 580;
        const decimal growth = 107;
        const decimal bonus = 475;

        var level = Level.From(8);

        var perLevelStat = new Stat(level, baseValue, growth) { Bonus = bonus };

        const decimal expectedValue = 1672.925m;

        Assert.That(perLevelStat.Total, Is.EqualTo(expectedValue).Within(0.1m));
    }
}