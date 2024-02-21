using BelgianLeague.Models;
using BelgianLeague.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BelgianLeague.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IAccountService _service;
    private readonly ISession _session;

    public UserController(ILogger<UserController> logger, IAccountService accountService, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _service = accountService;
        _session = httpContextAccessor.HttpContext.Session;
    }

    public IActionResult Register()
    {
       return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterUserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        var userId = _service.Register(dto);
        return RedirectToAction(nameof(Login), userId);
    }

    public IActionResult Login(int userId = 0)
    {
        var user = _service.GetUserById(userId);
        return View(user);
    }

    [HttpPost]
    public IActionResult Login(LoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        string email = _service.Login(dto, _session);
        if(string.IsNullOrEmpty(email))
        {
            ModelState.AddModelError("Email", "Invalid email or password");
            return View(dto);
        }
        return RedirectToAction("Index", "Home", email);
    }

    public IActionResult Logout()
    {
        _service.Logout(_session);
        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
