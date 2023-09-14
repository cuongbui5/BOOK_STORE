using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repository;

public interface IUserRepository
{
    User GetUserById(int userId);
    User GetUserByUsername(string username);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
    
}