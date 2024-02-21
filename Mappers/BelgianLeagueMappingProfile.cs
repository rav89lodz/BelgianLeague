using AutoMapper;
using BelgianLeague.Entities;
using BelgianLeague.Models;

namespace BelgianLeague.Mappers;

public class BelgianLeagueMappingProfile : Profile
{
    public BelgianLeagueMappingProfile()
    {
        CreateMap<League, LeagueDto>();

        CreateMap<Team, TeamDto>()
            .ForMember(t => t.NumberOfMatches, td => td.MapFrom(tm => tm.Statistics.Count()))
            .ForMember(t => t.Points, td => td.MapFrom(tm => tm.Statistics.Sum(s => s.PointsPerMatch)))
            .ForMember(t => t.GoalsScored, td => td.MapFrom(tm => tm.Statistics.Sum(s => s.GoalsScored)))
            .ForMember(t => t.GoalsConceded, td => td.MapFrom(tm => tm.Statistics.Sum(s => s.GoalsConceded)));

        CreateMap<Season, SeasonDto>();

        CreateMap<Team, MyTeamsDto>();

        CreateMap<Round, RoundDto>();

        CreateMap<RegisterUserDto, User>()
            .ForMember(u => u.PasswordHash, r => r.MapFrom(m => m.Password));

        CreateMap<User, LoginDto>()
            .ForMember(l => l.Password, u => u.MapFrom(m => m.PasswordHash));
    }
}
