using System.Collections.Generic;
using System.Linq;

public class UserRepository
{
    private readonly List<User> _users;

    public UserRepository()
    {
        // Inicializa algunos usuarios de ejemplo con contraseñas en texto plano (esto debería cambiarse para producción)
        _users = new List<User>
        {
            new User { Id = 1, Username = "Joaco", Password = "admin123" }, 
            new User { Id = 2, Username = "user1", Password = "password1" }
        };
    }

public User GetUserById(int id)
{
    var user = _users.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        throw new KeyNotFoundException($"No se encontró el usuario con Id {id}");
    }
    return user;
}

public User GetUserByUsername(string username)
{
    var user = _users.FirstOrDefault(u => u.Username == username);
    if (user == null)
    {
        throw new KeyNotFoundException($"No se encontró el usuario con el nombre de usuario {username}");
    }
    return user;
}
    public void AddUser(User user)
    {
        // Asegúrate de generar un ID único para el usuario y cifrar su contraseña
        user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
        _users.Add(user);
    }

    public void UpdateUser(User user)
    {
        var existingUser = GetUserById(user.Id);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.Password = user.Password; // Asegúrate de que la contraseña sea cifrada
        }
    }

    public void DeleteUser(int id)
    {
        var userToDelete = GetUserById(id);
        if (userToDelete != null)
        {
            _users.Remove(userToDelete);
        }
    }
}