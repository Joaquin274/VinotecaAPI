public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public void AddUser(User user)
    {
        // Se debería aplicar hash y salting para almacenar contraseñas de manera segura
        _userRepository.AddUser(user);
    }

    public void UpdateUser(User user)
    {
        // Asegúrate de que las contraseñas estén cifradas al ser actualizadas
        _userRepository.UpdateUser(user);
    }

    public void DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
    }

    public bool ValidateUser(string username, string password)
    {
        var user = _userRepository.GetUserByUsername(username);
        return user != null && user.Password == password;
    }
}