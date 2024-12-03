namespace LeagueOptimizer.Champions.Caitlyn.AbilityData;

public class CaitlynAbilityData
{
    public PassiveData Passive { get; set; }
    public SpellQData SpellQ { get; set; }
    public SpellWData SpellW { get; set; }
    public SpellEData SpellE { get; set; }
    public SpellRData SpellR { get; set; }

    public class PassiveData
    {
        public List<decimal> ChampionTotalAdScaling { get; set; }
        public List<decimal> TotalAdScaling { get; set; }
        public decimal CritScaling { get; set; }
        public decimal IeCritBonusScaling { get; set; }
    }

    public class SpellQData
    {
        public List<int> Cost { get; set; }
        public List<int> Cooldown { get; set; }
        public List<int> BaseDmg { get; set; }
        public List<decimal> TotalAdScaling { get; set; }
        public decimal ReducedDamageMultiplier { get; set; }
    }

    public class SpellWData
    {
        public int Cost { get; set; }
        public decimal Cooldown { get; set; }
        public List<int> Recharge { get; set; }
        public List<int> Duration { get; set; }
        public List<int> MaximumCharges { get; set; }
        public List<int> BaseDmg { get; set; }
        public decimal BonusAdScaling { get; set; }
    }

    public class SpellEData
    {
        public int Cost { get; set; }
        public List<int> Cooldown { get; set; }
        public List<int> BaseDmg { get; set; }
        public decimal ApScaling { get; set; }
        public decimal SlowAmount { get; set; }
        public decimal SlowDuration { get; set; }
    }

    public class SpellRData
    {
        public int Cost { get; set; }
        public int Cooldown { get; set; }
        public List<int> BaseDmg { get; set; }
        public decimal BonusAdScaling { get; set; }
        public decimal CritScaling { get; set; }
    }
}