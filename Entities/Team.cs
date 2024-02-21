namespace BelgianLeague.Entities;

public class Team
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int LeagueId {  get; set; }
    public virtual League League { get; set; }

    public virtual List<Statistics> Statistics { get; set; }
}
