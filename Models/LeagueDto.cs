using BelgianLeague.Entities;

namespace BelgianLeague.Models;

public class LeagueDto
{
    public string Name { get; set; }
    public byte LeagueNumber { get; set; }
    public List<SeasonDto> Seasons { get; set; }
    public List<TeamDto> Teams { get; set; }
}
