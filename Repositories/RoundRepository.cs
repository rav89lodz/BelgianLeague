using BelgianLeague.Entities;
using Microsoft.EntityFrameworkCore;

namespace BelgianLeague.Repositories;

public class RoundRepository : IRoundRepository
{
    private readonly BelgianLeagueDbContext _dbContext;
    public RoundRepository(BelgianLeagueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Round> GetAllRoundsBySeasonId(int id)
    {
        return _dbContext.Rounds.Where(r => r.SeasonId == id).Include(r => r.FirstTeam).Include(r => r.SecondTeam).ToList();
    }

    public List<Round> GetAllRoundsForTeamByTeamId(int id)
    {
        return _dbContext.Rounds.Where(r => r.FirstTeamId == id || r.SecondTeamId == id).Include(r => r.FirstTeam).Include(r => r.SecondTeam).ToList();
    }
}
