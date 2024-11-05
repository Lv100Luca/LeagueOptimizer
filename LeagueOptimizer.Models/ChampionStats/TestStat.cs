namespace LeagueOptimizer.Models.ChampionStats;

public class TestStat
{
    public int Base { get; set; }
    public int Growth { get; set; }

    override public string ToString()
    {
        return $"TestStat:\n" +
               $"  Base: {Base}\n" +
               $"  Growth: {Growth}";
    }
}