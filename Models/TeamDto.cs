namespace BelgianLeague.Models;

public class TeamDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Points { get; set; }
    public int GoalsScored { get; set; }
    public int GoalsConceded { get; set; }
    public int NumberOfMatches { get; set; }

    public List<RoundDto> Rounds { get; set; }
}
