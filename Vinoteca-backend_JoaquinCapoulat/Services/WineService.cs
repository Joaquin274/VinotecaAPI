using VinotecaBackend.Entities;
using VinotecaBackend.Repositories;
using VinotecaBackend.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinotecaBackend.Services
{
    public class WineService
    {
        private readonly WineRepository _wineRepository;

        public WineService(WineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public async Task<int> RegisterWineAsync(WineDTO wineDto)
        {
            if (string.IsNullOrWhiteSpace(wineDto.Name) || string.IsNullOrWhiteSpace(wineDto.Variety) || wineDto.Year <= 0 || wineDto.Stock < 0)
                throw new ArgumentException("Los campos nombre, variedad, año y stock son obligatorios y válidos.");

            var newWine = new Wine
            {
                Name = wineDto.Name,
                Variety = wineDto.Variety,
                Year = wineDto.Year,
                Region = wineDto.Region,
                Stock = wineDto.Stock
            };

            return await _wineRepository.CreateWineAsync(newWine);
        }

        public async Task<List<WineDTO>> GetAllWinesAsync()
        {
            var wines = await _wineRepository.RetrieveAllWinesAsync();
            return wines.Select(w => new WineDTO
            {
                id = w.Id,
                Name = w.Name,
                Variety = w.Variety,
                Year = w.Year,
                Region = w.Region,
                Stock = w.Stock
            }).ToList();
        }

        public async Task<WineDTO?> GetWineByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            var wine = await _wineRepository.FindWineByNameAsync(name);
            if (wine == null) return null;

            return new WineDTO
            {
                id = wine.Id,
                Name = wine.Name,
                Variety = wine.Variety,
                Year = wine.Year,
                Region = wine.Region,
                Stock = wine.Stock
            };
        }

        public async Task<bool> UpdateWineStockAsync(int id, int newStock)
        {
            return await _wineRepository.UpdateWineStockAsync(id, newStock);
        }
    }
}
