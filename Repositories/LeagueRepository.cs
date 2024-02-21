using BelgianLeague.Entities;
using Microsoft.EntityFrameworkCore;

namespace BelgianLeague.Repositories;

public class LeagueRepository : ILeagueRepository
{
    private readonly BelgianLeagueDbContext _dbContext;
    public LeagueRepository(BelgianLeagueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<League> GetAllLeaguesList()
    {
        return _dbContext.Leagues.Include(l => l.Seasons).Include(t => t.Teams).ToList();
    }
}
