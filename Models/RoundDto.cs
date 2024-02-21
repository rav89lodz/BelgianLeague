using BelgianLeague.Entities;

namespace BelgianLeague.Models;

public class RoundDto
{
    public int RoundNumber { get; set; }
    public DateOnly Date { get; set; }
    public Team FirstTeam { get; set; }
    public Team SecondTeam { get; set; }
}
