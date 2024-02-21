using BelgianLeague.Entities;

namespace BelgianLeague.Seeders;

public class SeasonSeeder
{
    private readonly BelgianLeagueDbContext _dbContext;

    public SeasonSeeder(BelgianLeagueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect() && !_dbContext.Seasons.Any())
        {
            var seasons = GetSeasons();
            _dbContext.Seasons.AddRange(seasons);
            _dbContext.SaveChanges();
        }
    }

    private IEnumerable<Season> GetSeasons()
    {
        return new List<Season>
        {
            new Season()
            {
                DateFrom = new DateOnly(2022, 07, 22),
                DateTo = new DateOnly(2023, 06, 04),
                LeagueId = 1
            }
        };
    }
}
