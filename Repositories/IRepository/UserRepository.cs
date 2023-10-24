using BOOK_STORE_DEMO.Data;
using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repository;

public class UserRepository:IUserRepository
{
    private readonly BookStoreDBContext context;

    public UserRepository(BookStoreDBContext context)
    {
        this.context = context;
    }
    
    public User GetUserById(int userId)
    {
        
        return context.Users.Find(userId);
    }

    public User GetUserByUsername(string username)
    {
        return context.Users.SingleOrDefault(u => u.Username == username);
    }

    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        context.Users.Update(user);
        context.SaveChanges();
    }

    public void DeleteUser(int userId)
    {
        var user = context.Users.Find(userId);
        if (user != null)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}