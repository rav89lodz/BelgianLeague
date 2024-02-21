using BelgianLeague.Entities;

namespace BelgianLeague.Repositories;

public interface ILeagueRepository
{
    public List<League> GetAllLeaguesList();
}
