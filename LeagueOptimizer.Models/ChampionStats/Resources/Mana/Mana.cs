namespace LeagueOptimizer.Models.ChampionStats.Resources.Mana;

public class Mana : IStat
{
    public int Total { get; set; }
    public int Base { get; set; }
    public int Bonus { get; set; }
    public int Growth { get; set; }
}