using System.Security.Claims;
using BOOK_STORE_DEMO.Dtos;
using BOOK_STORE_DEMO.Dtos.Request;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BOOK_STORE_DEMO.Services;

public class AuthService:IAuthService
{
    private readonly IUserRepository userRepository;

    public AuthService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    
    

    public void Register(UserDto userDto)
    {
        try
        {
            User user = userRepository.GetUserByUsername(userDto.Username);
            if (user != null)
            {
                throw new Exception("Email đã được đăng kí!");
            }
            User newUser = new User();
            newUser.Username = userDto.Username;
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            newUser.Role = "USER";
            newUser.CreatedAt = DateTime.Now;
            userRepository.AddUser(newUser);
            

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public User Login(LoginRequest loginRequest)
    {
        User user = userRepository.GetUserByUsername(loginRequest.Username);
        if (BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
        {
            return user;
        }

        return null;

    }

    public User GetUserByUsername(string username)
    {
        return userRepository.GetUserByUsername(username);
    }
}