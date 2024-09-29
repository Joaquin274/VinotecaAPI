public class User
{
    public int Id { get; set; }

    // Nombre de usuario, requerido y único
    public string Username { get; set; } = string.Empty;

    // Contraseña, al menos 8 caracteres
    public required string Password { get; set; }
}