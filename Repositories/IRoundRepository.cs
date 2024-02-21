using BelgianLeague.Entities;

namespace BelgianLeague.Repositories;

public interface IRoundRepository
{
    public List<Round> GetAllRoundsBySeasonId(int id);
    public List<Round> GetAllRoundsForTeamByTeamId(int id);
}
