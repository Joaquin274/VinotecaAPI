using Microsoft.AspNetCore.Mvc;
using VinotecaBackend.DTOs;
using VinotecaBackend.Entities;
using System.Threading.Tasks;

namespace VinotecaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO userDto)
        {
            if (string.IsNullOrEmpty(userDto.Username))
                return BadRequest("El nombre de usuario es obligatorio.");

            if (string.IsNullOrEmpty(userDto.Password))
                return BadRequest("La contraseña es obligatoria.");

            try
            {
                var userId = await _userService.RegisterUserAsync(userDto);
                return Ok(new { message = "Usuario registrado con éxito.", userId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar usuario: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users == null || !users.Any())
                return NotFound("No hay usuarios registrados.");

            return Ok(users);
        }
    }
}
