public class UserDTO
{
    public required string Username { get; set; }
    public string? Password { get; set; } // Esto permite que Password sea opcional (puede ser nulo)
}
