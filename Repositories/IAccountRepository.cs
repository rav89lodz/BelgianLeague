using BelgianLeague.Entities;
using BelgianLeague.Models;

namespace BelgianLeague.Repositories;

public interface IAccountRepository
{
    public int Create(User user);
    public User GetUserByEmailForLogin(LoginDto dto);
    public User GetUserById(int id);
}
