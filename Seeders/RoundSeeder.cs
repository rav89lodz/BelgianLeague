using BelgianLeague.Entities;

namespace BelgianLeague.Seeders;

public class RoundSeeder
{
    private readonly BelgianLeagueDbContext _dbContext;

    public RoundSeeder(BelgianLeagueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect() && !_dbContext.Rounds.Any())
        {
            var rounds = GetRounds();
            _dbContext.Rounds.AddRange(rounds);
            _dbContext.SaveChanges();
        }
    }

    private IEnumerable<Round> GetRounds()
    {
        return new List<Round>
        {
            new Round()
            {
               RoundNumber = 1,
               Date = new DateOnly(2022, 07, 24),
               FirstTeamId = 7,
               SecondTeamId = 8,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 1,
               Date = new DateOnly(2022, 07, 24),
               FirstTeamId = 11,
               SecondTeamId = 16,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 1,
               Date = new DateOnly(2022, 07, 24),
               FirstTeamId = 13,
               SecondTeamId = 3,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 1,
               Date = new DateOnly(2022, 07, 24),
               FirstTeamId = 4,
               SecondTeamId = 1,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 1,
               Date = new DateOnly(2022, 07, 23),
               FirstTeamId = 12,
               SecondTeamId = 2,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 1,
               Date = new DateOnly(2022, 07, 23),
               FirstTeamId = 14,
               SecondTeamId = 10,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 1,
               Date = new DateOnly(2022, 07, 23),
               FirstTeamId = 17,
               SecondTeamId = 18,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 1,
               Date = new DateOnly(2022, 07, 23),
               FirstTeamId = 9,
               SecondTeamId = 15,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 1,
               Date = new DateOnly(2022, 07, 22),
               FirstTeamId = 6,
               SecondTeamId = 5,
               SeasonId = 1,
            },


            /**********/


            new Round()
            {
               RoundNumber = 2,
               Date = new DateOnly(2022, 07, 31),
               FirstTeamId = 3,
               SecondTeamId = 17,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 2,
               Date = new DateOnly(2022, 07, 31),
               FirstTeamId = 18,
               SecondTeamId = 14,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 2,
               Date = new DateOnly(2022, 07, 31),
               FirstTeamId = 15,
               SecondTeamId = 4,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 2,
               Date = new DateOnly(2022, 07, 31),
               FirstTeamId = 1,
               SecondTeamId = 6,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 2,
               Date = new DateOnly(2022, 07, 30),
               FirstTeamId = 5,
               SecondTeamId = 12,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 2,
               Date = new DateOnly(2022, 07, 30),
               FirstTeamId = 10,
               SecondTeamId = 7,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 2,
               Date = new DateOnly(2022, 07, 30),
               FirstTeamId = 16,
               SecondTeamId = 13,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 2,
               Date = new DateOnly(2022, 07, 30),
               FirstTeamId = 8,
               SecondTeamId = 11,
               SeasonId = 1,
            },
            new Round()
            {
               RoundNumber = 2,
               Date = new DateOnly(2022, 07, 29),
               FirstTeamId = 2,
               SecondTeamId = 9,
               SeasonId = 1,
            },
        };
    }
}
