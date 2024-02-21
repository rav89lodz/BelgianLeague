using BelgianLeague.Entities;
using BelgianLeague.Models;

namespace BelgianLeague.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly BelgianLeagueDbContext _dbContext;

    public AccountRepository(BelgianLeagueDbContext context)
    {
        _dbContext = context;
    }
    public int Create(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return user.Id;
    }

    public User GetUserByEmailForLogin(LoginDto dto)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == dto.Email);
    }
    public User GetUserById(int id)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Id == id);
    }
}
