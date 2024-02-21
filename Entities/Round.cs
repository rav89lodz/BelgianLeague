namespace BelgianLeague.Entities;

public class Round
{
    public int Id { get; set; }
    public required int RoundNumber { get; set; }
    public required DateOnly Date { get; set; }

    public int FirstTeamId { get; set; }
    public virtual Team FirstTeam { get; set; }
    public int SecondTeamId { get; set; }
    public virtual Team SecondTeam { get; set; }

    public int SeasonId { get; set; }
    public virtual Season Season { get; set; }
}
