namespace BOOK_STORE_DEMO.Validate;

public class Validatator
{
    public static bool isEmailValid(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
        
    }
}