using BelgianLeague.Entities;

namespace BelgianLeague.Repositories;

public class MyTeamRepository : IMyTeamRepository
{
    private readonly BelgianLeagueDbContext _context;

    public MyTeamRepository(BelgianLeagueDbContext context)
    {
        _context = context;
    }

    public List<MyTeam> GetTeamsForUser(int userId)
    {
        return _context.MyTeams.Where(m => m.UserId == userId).ToList();
    }
    public MyTeam GetTeamByUserIdAndTeamId(int userId, int teamId)
    {
        return _context.MyTeams.Where(m => m.UserId == userId && m.TeamId == teamId).FirstOrDefault();
    }

    public int AddToFavorite(int userId, int teamId)
    {
        MyTeam myTeam = new MyTeam()
        {
            UserId = userId,
            TeamId = teamId
        };
        _context.MyTeams.Add(myTeam);
        var result = _context.SaveChanges();
        return result;
    }
    public int RemoveFromFavorite(int userId, int teamId)
    {
        MyTeam team = GetTeamByUserIdAndTeamId(userId, teamId);
        if(team != null)
        {
            _context.MyTeams.Remove(team);
            return _context.SaveChanges();
        }
        return 0;
    }
}
