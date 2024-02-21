using BelgianLeague.Authorization;
using BelgianLeague.Entities;
using BelgianLeague.Models.Validators;
using BelgianLeague.Models;
using BelgianLeague.Seeders;
using BelgianLeague.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using BelgianLeague.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(); ;

builder.Services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();

builder.Services.AddDbContext<BelgianLeagueDbContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("BelgianLeagueDbConnection"),
                        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("BelgianLeagueDbConnection"))));

// Add session
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<LeagueSeeder>();
builder.Services.AddScoped<TeamSeeder>();
builder.Services.AddScoped<SeasonSeeder>();
builder.Services.AddScoped<RoundSeeder>();
builder.Services.AddScoped<StatisticsSeeder>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILeagueService, LeagueService>();
builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();
builder.Services.AddScoped<IRoundRepository, RoundRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IMyTeamRepository, MyTeamRepository>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();

var app = builder.Build();

app.UseResponseCaching();

using (IServiceScope scope = app.Services.CreateScope())
{
    var leagueSeeder = scope.ServiceProvider.GetService<LeagueSeeder>();
    leagueSeeder?.Seed();

    var teamSeeder = scope.ServiceProvider.GetService<TeamSeeder>();
    teamSeeder?.Seed();

    var seasonSeeder = scope.ServiceProvider.GetService<SeasonSeeder>();
    seasonSeeder?.Seed();

    var roundSeeder = scope.ServiceProvider.GetService<RoundSeeder>();
    roundSeeder?.Seed();

    var statisticsSeeder = scope.ServiceProvider.GetService<StatisticsSeeder>();
    statisticsSeeder?.Seed();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
