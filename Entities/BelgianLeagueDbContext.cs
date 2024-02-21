using Microsoft.EntityFrameworkCore;

namespace BelgianLeague.Entities;

public class BelgianLeagueDbContext : DbContext
{
    public BelgianLeagueDbContext(DbContextOptions<BelgianLeagueDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<MyTeam> MyTeams { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Statistics> Statistics { get; set; }
    public DbSet<Round> Rounds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().Property(t => t.Name).IsRequired().HasMaxLength(100);

        modelBuilder.Entity<MyTeam>().Property(mt => mt.TeamId).IsRequired();

        modelBuilder.Entity<MyTeam>().Property(mt => mt.UserId).IsRequired();

        modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();

        modelBuilder.Entity<League>().Property(l => l.Name).IsRequired().HasMaxLength (100);

        modelBuilder.Entity<League>().Property(l => l.LeagueNumber).IsRequired();

        modelBuilder.Entity<Season>().Property(s => s.DateFrom).IsRequired();

        modelBuilder.Entity<Season>().Property(s => s.DateTo).IsRequired();

        modelBuilder.Entity<Statistics>().Property(st => st.PointsPerMatch).IsRequired();

        modelBuilder.Entity<Statistics>().Property(st => st.GoalsConceded).IsRequired();

        modelBuilder.Entity<Statistics>().Property(st => st.GoalsScored).IsRequired();

        modelBuilder.Entity<Round>().Property(r => r.RoundNumber).IsRequired();

        modelBuilder.Entity<Round>().Property(r => r.Date).IsRequired();
    }

    // add-migration Init - tworzenie migracji na podstawie tego pliku
    // update-database - tworzenie db
    // remove-migration - usuwanie ostatniej migracji
}
