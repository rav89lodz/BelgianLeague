using BelgianLeague.Models;

namespace BelgianLeague.Services;

public interface ILeagueService
{
    public List<LeagueDto> getData();
    public TeamDto GetTeamDtoById(int id);
}
