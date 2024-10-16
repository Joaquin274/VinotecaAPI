using VinotecaBackend.Entities;
using VinotecaBackend.Repositories;
using VinotecaBackend.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> RegisterUserAsync(UserDTO userDto)
    {
        if (string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Password))
            throw new ArgumentException("El nombre de usuario y la contraseña son obligatorios.");

        var newUser = new User
        {
            Username = userDto.Username,
            Password = userDto.Password // Aquí puedes aplicar hashing si lo deseas
        };

        return await _userRepository.AddUserAsync(newUser);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetUsersAsync();
        return users.Select(u => new UserDTO
        {
            Username = u.Username
        }).ToList();
    }
}
