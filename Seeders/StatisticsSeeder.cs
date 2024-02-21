using BelgianLeague.Entities;

namespace BelgianLeague.Seeders;

public class StatisticsSeeder
{
    private readonly BelgianLeagueDbContext _dbContext;

    public StatisticsSeeder(BelgianLeagueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect() && !_dbContext.Statistics.Any())
        {
            var statistics = GetStatistics();
            _dbContext.Statistics.AddRange(statistics);
            _dbContext.SaveChanges();
        }
    }

    private IEnumerable<Statistics> GetStatistics()
    {
        return new List<Statistics>
        {
            new Statistics()
            {
                TeamId = 7,
                PointsPerMatch = 3,
                GoalsScored = 2,
                GoalsConceded = 0
            },
            new Statistics()
            {
                TeamId = 8,
                PointsPerMatch = 0,
                GoalsScored = 0,
                GoalsConceded = 2
            },

            new Statistics()
            {
                TeamId = 11,
                PointsPerMatch = 3,
                GoalsScored = 2,
                GoalsConceded = 0
            },
            new Statistics()
            {
                TeamId = 16,
                PointsPerMatch = 0,
                GoalsScored = 0,
                GoalsConceded = 2
            },

            new Statistics()
            {
                TeamId = 13,
                PointsPerMatch = 0,
                GoalsScored = 0,
                GoalsConceded = 2
            },
            new Statistics()
            {
                TeamId = 3,
                PointsPerMatch = 3,
                GoalsScored = 2,
                GoalsConceded = 0
            },

            new Statistics()
            {
                TeamId = 4,
                PointsPerMatch = 3,
                GoalsScored = 3,
                GoalsConceded = 2
            },
            new Statistics()
            {
                TeamId = 1,
                PointsPerMatch = 0,
                GoalsScored = 2,
                GoalsConceded = 3
            },

            new Statistics()
            {
                TeamId = 12,
                PointsPerMatch = 1,
                GoalsScored = 1,
                GoalsConceded = 1
            },
            new Statistics()
            {
                TeamId = 2,
                PointsPerMatch = 1,
                GoalsScored = 1,
                GoalsConceded = 1
            },

            new Statistics()
            {
                TeamId = 14,
                PointsPerMatch = 0,
                GoalsScored = 0,
                GoalsConceded = 2
            },
            new Statistics()
            {
                TeamId = 10,
                PointsPerMatch = 3,
                GoalsScored = 2,
                GoalsConceded = 0
            },

            new Statistics()
            {
                TeamId = 17,
                PointsPerMatch = 3,
                GoalsScored = 2,
                GoalsConceded = 0
            },
            new Statistics()
            {
                TeamId = 18,
                PointsPerMatch = 0,
                GoalsScored = 0,
                GoalsConceded = 2
            },

            new Statistics()
            {
                TeamId = 9,
                PointsPerMatch = 3,
                GoalsScored = 3,
                GoalsConceded = 1
            },
            new Statistics()
            {
                TeamId = 15,
                PointsPerMatch = 0,
                GoalsScored = 1,
                GoalsConceded = 3
            },

            new Statistics()
            {
                TeamId = 6,
                PointsPerMatch = 1,
                GoalsScored = 2,
                GoalsConceded = 2
            },
            new Statistics()
            {
                TeamId = 5,
                PointsPerMatch = 1,
                GoalsScored = 2,
                GoalsConceded = 2
            },

            /**********/

            new Statistics()
            {
                TeamId = 3,
                PointsPerMatch = 3,
                GoalsScored = 1,
                GoalsConceded = 0
            },
            new Statistics()
            {
                TeamId = 17,
                PointsPerMatch = 0,
                GoalsScored = 0,
                GoalsConceded = 1
            },

            new Statistics()
            {
                TeamId = 18,
                PointsPerMatch = 0,
                GoalsScored = 0,
                GoalsConceded = 1
            },
            new Statistics()
            {
                TeamId = 14,
                PointsPerMatch = 3,
                GoalsScored = 1,
                GoalsConceded = 0
            },

            new Statistics()
            {
                TeamId = 15,
                PointsPerMatch = 3,
                GoalsScored = 2,
                GoalsConceded = 1
            },
            new Statistics()
            {
                TeamId = 4,
                PointsPerMatch = 0,
                GoalsScored = 1,
                GoalsConceded = 2
            },

            new Statistics()
            {
                TeamId = 1,
                PointsPerMatch = 3,
                GoalsScored = 3,
                GoalsConceded = 1
            },
            new Statistics()
            {
                TeamId = 6,
                PointsPerMatch = 0,
                GoalsScored = 1,
                GoalsConceded = 3
            },

            new Statistics()
            {
                TeamId = 5,
                PointsPerMatch = 1,
                GoalsScored = 1,
                GoalsConceded = 1
            },
            new Statistics()
            {
                TeamId = 12,
                PointsPerMatch = 1,
                GoalsScored = 1,
                GoalsConceded = 1
            },

            new Statistics()
            {
                TeamId = 10,
                PointsPerMatch = 3,
                GoalsScored = 2,
                GoalsConceded = 0
            },
            new Statistics()
            {
                TeamId = 7,
                PointsPerMatch = 0,
                GoalsScored = 0,
                GoalsConceded = 2
            },

            new Statistics()
            {
                TeamId = 16,
                PointsPerMatch = 3,
                GoalsScored = 2,
                GoalsConceded = 1
            },
            new Statistics()
            {
                TeamId = 13,
                PointsPerMatch = 0,
                GoalsScored = 1,
                GoalsConceded = 2
            },

            new Statistics()
            {
                TeamId = 8,
                PointsPerMatch = 3,
                GoalsScored = 1,
                GoalsConceded = 0
            },
            new Statistics()
            {
                TeamId = 11,
                PointsPerMatch = 0,
                GoalsScored = 0,
                GoalsConceded = 1
            },

            new Statistics()
            {
                TeamId = 2,
                PointsPerMatch = 3,
                GoalsScored = 1,
                GoalsConceded = 0
            },
            new Statistics()
            {
                TeamId = 9,
                PointsPerMatch = 0,
                GoalsScored = 0,
                GoalsConceded = 1
            },
        };
    }
}
