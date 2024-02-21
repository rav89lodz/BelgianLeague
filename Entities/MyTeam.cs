namespace BelgianLeague.Entities;

public class MyTeam
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int TeamId { get; set; }
    public virtual List<Team> Team { get; set; }
}
