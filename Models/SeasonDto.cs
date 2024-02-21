using BelgianLeague.Entities;

namespace BelgianLeague.Models;

public class SeasonDto
{
    public int Id { get; set;  }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public League League { get; set; }
    public List<RoundDto> Rounds { get; set; }
}
