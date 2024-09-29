using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> GetMenu()
    {
        // Devuelve el menú principal
        return "Bienvenido a la vinoteca de Joaquin Capoulat, ¿qué es lo que quiere hacer?";
    }

    [HttpPost("add-wine")]
    public ActionResult<string> AddWine([FromBody] Wine wine)
    {
        // Aquí añadirías lógica para agregar un vino
        // Supongamos que ya se ha añadido el vino al inventario:
        return Ok($"Vino '{wine.Name}' añadido con éxito.");
    }

    [HttpPost("replace-wine")]
    public ActionResult<string> ReplaceWine([FromBody] Wine wine)
    {
        // Aquí añadirías la lógica para sustituir un vino en el inventario.
        return Ok($"Vino '{wine.Name}' reemplazado con éxito.");
    }

    [HttpGet("list-wines")]
    public ActionResult<IEnumerable<Wine>> ListWines()
    {
        // Aquí deberías obtener la lista de vinos desde algún servicio o repositorio.
        var wines = new List<Wine> // Ejemplo estático de vinos.
        {
            new Wine { Name = "Malbec", Year = 2021, Region = "Mendoza" },
            new Wine { Name = "Cabernet", Year = 2018, Region = "Salta" }
        };

        return Ok(wines);
    }
}
