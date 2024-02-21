using BelgianLeague.Models;

namespace BelgianLeague.Services;

public interface ITeamService
{
    public List<MyTeamsDto> GetTeams(ISession session);
    public int AddToFavorite(MyTeamsDtoRequest request);
    public int RemoveFromFavorite(MyTeamsDtoRequest request);
}
