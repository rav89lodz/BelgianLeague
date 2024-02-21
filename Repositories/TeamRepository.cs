using BelgianLeague.Entities;
using Microsoft.EntityFrameworkCore;

namespace BelgianLeague.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly BelgianLeagueDbContext _context;

    public TeamRepository(BelgianLeagueDbContext context)
    {
        _context = context;
    }
    public Team GetTeamById(int id)
    {
        return _context.Teams.Include(t => t.Statistics).FirstOrDefault(t => t.Id == id);
    }
    public List<Team> GetTeams()
    {
        return _context.Teams.ToList();
    }
}
