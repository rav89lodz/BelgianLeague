namespace BelgianLeague.Entities;

public class League
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required byte LeagueNumber { get; set; }
    public virtual List<Season> Seasons { get; set; }
    public virtual List<Team> Teams { get; set; }
}
