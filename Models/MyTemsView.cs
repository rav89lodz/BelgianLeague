namespace BelgianLeague.Models;

public class MyTemsView
{
    public List<MyTeamsDto> Teams { get; set; }
    public string UserEmail { get; set; }
    public int UserId { get; set; }

    public MyTemsView(List<MyTeamsDto> teams, string userEmail, int userId)
    {
        Teams = teams;
        UserEmail = userEmail;
        UserId = userId;
    }
}
