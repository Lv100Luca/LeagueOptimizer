﻿namespace LeagueOptimizer.Models.ChampionStats;

public class AttackDamage : IStat
{
    public int Total { get; set; }
    public int Base { get; set; }
    public int Bonus { get; set; }
    public int Growth { get; set; }
}