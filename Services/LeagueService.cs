using AutoMapper;
using BelgianLeague.Models;
using BelgianLeague.Repositories;

namespace BelgianLeague.Services;

public class LeagueService : ILeagueService
{
    private readonly ILeagueRepository _leagueRepository;
    private readonly IRoundRepository _roundRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public LeagueService(ILeagueRepository leagueRepository, IMapper mapper, IRoundRepository roundRepository, ITeamRepository teamRepository)
    {
        _leagueRepository = leagueRepository;
        _roundRepository = roundRepository;
        _mapper = mapper;
        _teamRepository = teamRepository;
    }

    public List<LeagueDto> getData()
    {
        var leagues = _mapper.Map<List<LeagueDto>>(_leagueRepository.GetAllLeaguesList());
        if (leagues[0].Seasons.Count > 0)
        {
            var seasons = leagues[0].Seasons.OrderBy(s => s.DateFrom);
            leagues[0].Seasons[0].Rounds = _mapper.Map<List<RoundDto>>(_roundRepository.GetAllRoundsBySeasonId(seasons.First().Id));
        }
        if (leagues[0].Teams.Count > 0)
        {
            for(int i = 0; i < leagues[0].Teams.Count; i++)
            {
                leagues[0].Teams[i] = _mapper.Map<TeamDto>(_teamRepository.GetTeamById(leagues[0].Teams[i].Id));
            }
        }
        leagues[0].Teams = leagues[0].Teams.OrderByDescending(t => t.Points).ThenByDescending(t => t.GoalsScored).ToList();
        return leagues;
    }

    public TeamDto GetTeamDtoById(int id)
    {
        TeamDto teamDto = new TeamDto();
        if (id < 1)
        {
            return teamDto;
        }
        teamDto = _mapper.Map<TeamDto>(_teamRepository.GetTeamById(id));
        if(teamDto == null)
        {
            return teamDto;
        }
        teamDto.Rounds = _mapper.Map<List<RoundDto>>(_roundRepository.GetAllRoundsForTeamByTeamId(id));
        return teamDto;
    }
}
