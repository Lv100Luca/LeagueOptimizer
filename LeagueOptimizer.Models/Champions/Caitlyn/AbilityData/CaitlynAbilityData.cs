namespace LeagueOptimizer.Models.Champions.Caitlyn.AbilityData;

public class CaitlynAbilityData
{
    public PassiveData Passive { get; set; }
    public SpellQData SpellQ { get; set; }
    public SpellWData SpellW { get; set; }
    public SpellEData SpellE { get; set; }
    public SpellRData SpellR { get; set; }

    public class PassiveData
    {
        public List<int> ChampionBaseDmg { get; set; }
        public List<int> BaseDmg { get; set; }
        public double CritScaling { get; set; }
        public double IeCritScaling { get; set; }
    }

    public class SpellQData
    {
        public List<int> Cost { get; set; }
        public List<int> Cooldown { get; set; }
        public List<int> BaseDmg { get; set; }
        public List<double> TotalAdScaling { get; set; }
        public double ReducedDamageMultiplier { get; set; }
    }

    public class SpellWData
    {
        public int Cost { get; set; }
        public double Cooldown { get; set; }
        public List<int> Recharge { get; set; }
        public List<int> Duration { get; set; }
        public List<int> MaximumCharges { get; set; }
        public List<int> BaseDmg { get; set; }
        public double BonusAdScaling { get; set; }
    }

    public class SpellEData
    {
        public int Cost { get; set; }
        public List<int> Cooldown { get; set; }
        public List<int> BaseDmg { get; set; }
        public double ApScaling { get; set; }
        public double SlowAmount { get; set; }
        public double SlowDuration { get; set; }
    }

    public class SpellRData
    {
        public int Cost { get; set; }
        public int Cooldown { get; set; }
        public List<int> BaseDmg { get; set; }
        public double BonusAdScaling { get; set; }
        public double CritScaling { get; set; }
    }
}