using AutoMapper;
using BelgianLeague.Entities;
using BelgianLeague.Models;
using BelgianLeague.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BelgianLeague.Services;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IAccountRepository _repository;

    public AccountService(IMapper mapper, IPasswordHasher<User> passwordHasher, IAccountRepository repository)
    {
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _repository = repository;
    }

    public int Register(RegisterUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
        return _repository.Create(user);
    }

    public string Login(LoginDto dto, ISession session)
    {
        var user = _repository.GetUserByEmailForLogin(dto);
        if (user is null)
        {
            return "";
        }
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            return "";
        }
        session.SetString("UserEmail", user.Email);
        session.SetString("UserId", user.Id.ToString());
        return user.Email;
    }

    public void Logout(ISession session)
    {
        session.SetString("UserEmail", "");
        session.SetString("UserId", "");
    }

    public LoginDto GetUserById(int id)
    {
        LoginDto loginDto = new LoginDto();
        var user = _repository.GetUserById(id);
        if (user is null)
        {
            return loginDto;
        }
        loginDto = _mapper.Map<LoginDto>(user);
        return loginDto;
    }
}
