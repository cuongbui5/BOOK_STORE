using BOOK_STORE_DEMO.Dtos;

namespace BOOK_STORE_DEMO.Services;

public interface IAuthService
{
    void Register(UserDto userDto);
    
}