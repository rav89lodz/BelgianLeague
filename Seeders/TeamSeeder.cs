using BelgianLeague.Entities;
using Microsoft.EntityFrameworkCore;

namespace BelgianLeague.Seeders;

public class TeamSeeder
{
    private readonly BelgianLeagueDbContext _dbContext;

    public TeamSeeder(BelgianLeagueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect() && !_dbContext.Teams.Any())
        {
            var pendingMigrations = _dbContext.Database.GetPendingMigrations();
            if (pendingMigrations != null && pendingMigrations.Any())
            {
                _dbContext.Database.Migrate();
            }

            var teams = GetTeams();
            _dbContext.Teams.AddRange(teams);
            _dbContext.SaveChanges();
        }
    }

    private IEnumerable<Team> GetTeams()
    {
        return new List<Team>
        {
            new Team() { Name = "Genk", LeagueId = 1 }, // 1 ++
            new Team() { Name = "Royale Union SG", LeagueId = 1 }, // 2 ++
            new Team() { Name = "Antwerp", LeagueId = 1 }, // 3 ++
            new Team() { Name = "Club Brugge", LeagueId = 1 }, // 4 ++
            new Team() { Name = "Gent", LeagueId = 1 }, // 5 ++
            new Team() { Name = "St. Liege", LeagueId = 1 }, // 6 ++
            new Team() { Name = "Westerlo", LeagueId = 1 }, // 7 ++
            new Team() { Name = "Cercle Brugge", LeagueId = 1 }, // 8 ++
            new Team() { Name = "Charleroi", LeagueId = 1 }, // 9 ++
            new Team() { Name = "Leuven", LeagueId = 1 }, // 10 ++
            new Team() { Name = "Anderlecht", LeagueId = 1 }, // 11 ++
            new Team() { Name = "St. Truiden", LeagueId = 1 }, // 12 ++
            new Team() { Name = "KV Mechelen", LeagueId = 1 }, // 13 ++
            new Team() { Name = "Kortrijk", LeagueId = 1 }, // 14 ++
            new Team() { Name = "Eupen", LeagueId = 1 }, // 15 ++
            new Team() { Name = "Oostende", LeagueId = 1 }, // 16 ++
            new Team() { Name = "Waregem", LeagueId = 1 }, // 17 ++
            new Team() { Name = "Seraing", LeagueId = 1 } // 18 ++
        };
    }
}
