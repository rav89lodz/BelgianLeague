using BelgianLeague.Models;

namespace BelgianLeague.Services;

public interface IAccountService
{
    public int Register(RegisterUserDto dto);
    public string Login(LoginDto dto, ISession session);
    public void Logout(ISession session);
    public LoginDto GetUserById(int id);
}
