public class AuthService
{
    private readonly List<User> _users;

    public AuthService()
    {

        _users = new List<User>
        {
            new User { Id = 1, Username = "Joaquin", Password = "1234" }
        };
    }

    public User? Login(string username, string password)
    {
        return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}
