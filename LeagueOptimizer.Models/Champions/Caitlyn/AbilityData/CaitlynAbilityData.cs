namespace LeagueOptimizer.Models.Champions.Caitlyn.AbilityData;

public class CaitlynAbilityData
{
    public required PassiveData Passive { get; set; }
    public required SpellQData SpellQ { get; set; }
    public required SpellWData SpellW { get; set; }
    public required SpellEData SpellE { get; set; }
    public required SpellRData SpellR { get; set; }

    public class PassiveData
    {
        public required List<decimal> ChampionTotalAdScaling { get; set; }
        public required List<decimal> TotalAdScaling { get; set; }
        public required decimal CritScaling { get; set; }
        public required decimal IeCritBonusScaling { get; set; }
    }

    public class SpellQData
    {
        public required List<int> Cost { get; set; }
        public required List<int> Cooldown { get; set; }
        public required List<int> BaseDmg { get; set; }
        public required List<decimal> TotalAdScaling { get; set; }
        public required decimal ReducedDamageMultiplier { get; set; }
    }

    public class SpellWData
    {
        public required int Cost { get; set; }
        public required decimal Cooldown { get; set; }
        public required List<int> Recharge { get; set; }
        public required List<int> Duration { get; set; }
        public required List<int> MaximumCharges { get; set; }
        public required List<int> BaseDmg { get; set; }
        public required decimal BonusAdScaling { get; set; }
    }

    public class SpellEData
    {
        public required int Cost { get; set; }
        public required List<int> Cooldown { get; set; }
        public required List<int> BaseDmg { get; set; }
        public required decimal ApScaling { get; set; }
        public required decimal SlowAmount { get; set; }
        public required decimal SlowDuration { get; set; }
    }

    public class SpellRData
    {
        public required int Cost { get; set; }
        public required int Cooldown { get; set; }
        public required List<int> BaseDmg { get; set; }
        public required decimal BonusAdScaling { get; set; }
        public required decimal CritScaling { get; set; }
    }
}