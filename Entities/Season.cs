namespace BelgianLeague.Entities;

public class Season
{
    public int Id { get; set; }
    public required DateOnly DateFrom { get; set; }
    public required DateOnly DateTo { get; set; }
    public int LeagueId { get; set; }
    public virtual League League { get; set; }
    public virtual List<Round> Rounds { get; set; }
}
