using Microsoft.AspNetCore.Mvc;
using VinotecaBackend.DTOs;
using VinotecaBackend.Services;

namespace VinotecaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WineController : ControllerBase
    {
        private readonly WineService _wineService;

        public WineController(WineService wineService)
        {
            _wineService = wineService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterWine([FromBody] WineDTO wineDTO)
        {
            if (string.IsNullOrEmpty(wineDTO.Name))
                return BadRequest("El nombre del vino es obligatorio.");

            if (string.IsNullOrEmpty(wineDTO.Variety))
                return BadRequest("La variedad del vino es obligatoria.");

            if (wineDTO.Year <= 0)
                return BadRequest("Debe ingresar un año válido para el vino.");

            if (wineDTO.Stock < 0)
                return BadRequest("El stock no puede ser negativo.");

            try
            {
                var wineId = await _wineService.RegisterWineAsync(wineDTO);
                return Ok(new { message = "Vino registrado con éxito.", wineId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar vino: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetInventory()
        {
            var wines = await _wineService.GetAllWinesAsync();
            if (wines == null || !wines.Any())
                return NotFound("No hay vinos en el inventario.");

            return Ok(wines);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetWineByName(string name)
        {
            var wine = await _wineService.GetWineByNameAsync(name);
            if (wine == null)
                return NotFound("Vino no encontrado.");

            return Ok(wine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWineStock(int id, [FromBody] int newStock)
        {
            if (newStock < 0)
                return BadRequest("El stock no puede ser negativo.");

            try
            {
                var result = await _wineService.UpdateWineStockAsync(id, newStock);
                if (!result)
                    return NotFound("Vino no encontrado.");

                return Ok("Stock actualizado con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el stock: {ex.Message}");
            }
        }
    }
}
