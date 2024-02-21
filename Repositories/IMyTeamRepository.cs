using BelgianLeague.Entities;

namespace BelgianLeague.Repositories;

public interface IMyTeamRepository
{
    public List<MyTeam> GetTeamsForUser(int userId);
    public MyTeam GetTeamByUserIdAndTeamId(int userId, int teamId);
    public int AddToFavorite(int userId, int teamId);
    public int RemoveFromFavorite(int userId, int teamId);
}
