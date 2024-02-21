using BelgianLeague.Entities;
using BelgianLeague.Models;

namespace BelgianLeague.Repositories;

public interface ITeamRepository
{
    public Team GetTeamById(int id);
    public List<Team> GetTeams();
}
