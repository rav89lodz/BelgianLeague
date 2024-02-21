using AutoMapper;
using BelgianLeague.Entities;
using BelgianLeague.Models;
using BelgianLeague.Repositories;

namespace BelgianLeague.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _repository;
    private readonly IMyTeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public TeamService(ITeamRepository repository, IMapper mapper, IMyTeamRepository teamRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _teamRepository = teamRepository;
    }

    public List<MyTeamsDto> GetTeams(ISession session)
    {
        List<MyTeamsDto> teamDtos = new List<MyTeamsDto>();
        string userId = session.GetString("UserId");
        if(string.IsNullOrEmpty(userId))
        {
            return teamDtos;
        }
        teamDtos = _mapper.Map<List<MyTeamsDto>>(_repository.GetTeams());
        int userIdInt = Int32.Parse(userId);
        List<MyTeam> myTeams = _teamRepository.GetTeamsForUser(userIdInt);
        for (int i = 0; i < teamDtos.Count; i++)
        {
            bool result = false;
            for (int j = 0; j < myTeams.Count; j++)
            {
                if (myTeams[j].TeamId == teamDtos[i].Id)
                {
                    result = true;
                    break;
                }
            }
            teamDtos[i].IsFavorite = result;
        }
        return teamDtos.OrderByDescending(t => t.IsFavorite).ToList();
    }

    public int AddToFavorite(MyTeamsDtoRequest request)
    {
        return _teamRepository.AddToFavorite(request.UserId, request.TeamId);
    }

    public int RemoveFromFavorite(MyTeamsDtoRequest request)
    {
        return _teamRepository.RemoveFromFavorite(request.UserId, request.TeamId);
    }
}
