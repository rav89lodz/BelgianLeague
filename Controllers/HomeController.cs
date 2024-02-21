using BelgianLeague.Models;
using BelgianLeague.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BelgianLeague.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILeagueService _service;

    public HomeController(ILogger<HomeController> logger, ILeagueService leagueService)
    {
        _logger = logger;
        _service = leagueService;
    }

    public IActionResult Index()
    {
        var data = _service.getData();
        return View(data);
    }

    [HttpGet("{id}")]
    public ActionResult<TeamDto> Details([FromQuery] int id)
    {
        JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
        return Ok(JsonSerializer.Serialize(_service.GetTeamDtoById(id), options));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
