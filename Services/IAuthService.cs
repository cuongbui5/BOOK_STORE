using BOOK_STORE_DEMO.Dtos;
using BOOK_STORE_DEMO.Dtos.Request;
using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Services;

public interface IAuthService
{
    void Register(UserDto userDto);
    User Login(LoginRequest loginRequest);
    
}