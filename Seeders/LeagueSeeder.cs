using BelgianLeague.Entities;

namespace BelgianLeague.Seeders;

public class LeagueSeeder
{
    private readonly BelgianLeagueDbContext _dbContext;

    public LeagueSeeder(BelgianLeagueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect() && !_dbContext.Leagues.Any())
        {
            var leagues = GetLeagues();
            _dbContext.Leagues.AddRange(leagues);
            _dbContext.SaveChanges();
        }
    }

    private IEnumerable<League> GetLeagues()
    {
        return new List<League>
        {
            new League()
            {
                Name = "Jupiler League",
                LeagueNumber = 1,
            }
        };
    }
}
