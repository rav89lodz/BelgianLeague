using BelgianLeague.Models;
using BelgianLeague.Services;
using Microsoft.AspNetCore.Mvc;

namespace BelgianLeague.Controllers;

public class MyTeamsController : Controller
{
    private readonly ILogger<MyTeamsController> _logger;
    private readonly ISession _session;
    private readonly ITeamService _teamService;

    public MyTeamsController(ILogger<MyTeamsController> logger, IHttpContextAccessor httpContextAccessor, ITeamService teamService)
    {
        _logger = logger;
        _session = httpContextAccessor.HttpContext.Session;
        _teamService = teamService;
    }

    public IActionResult TeamList([FromQuery] MyTeamsDtoRequest request)
    {
        if(string.IsNullOrEmpty(_session.GetString("UserEmail")))
        {
            return RedirectToAction("Login", "User");
        }
        
        if(request != null && request.Action == Enums.RequestActions.Add)
        {
            _teamService.AddToFavorite(request);
        }
        if(request != null && request.Action == Enums.RequestActions.Remove)
        {
            _teamService.RemoveFromFavorite(request);
        }
        
        MyTemsView myTemsView = new MyTemsView(_teamService.GetTeams(_session), _session.GetString("UserEmail"), int.Parse(_session.GetString("UserId")));
        return View(myTemsView);
    }
}
