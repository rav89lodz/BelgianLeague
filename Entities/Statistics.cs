namespace BelgianLeague.Entities;

public class Statistics
{
    public int Id { get; set; }
    public required int PointsPerMatch { get; set; }
    public required int GoalsScored { get; set; }
    public required int GoalsConceded { get; set; }
    public int TeamId { get; set; }
    public virtual Team Team { get; set; }
}
