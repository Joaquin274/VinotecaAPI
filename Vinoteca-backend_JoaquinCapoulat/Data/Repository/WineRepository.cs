using VinotecaBackend.Data;
using Microsoft.EntityFrameworkCore;
using VinotecaBackend.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VinotecaBackend.Repositories
{
    public class WineRepository
    {
        private readonly ApplicationContext _dbContext;

        public WineRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateWineAsync(Wine wine)
        {
            await _dbContext.Wines.AddAsync(wine);
            await _dbContext.SaveChangesAsync();
            return wine.Id;
        }

        public async Task<IEnumerable<Wine>> RetrieveAllWinesAsync()
        {
            return await _dbContext.Wines.AsNoTracking().ToListAsync();
        }

        public async Task<Wine?> FindWineByNameAsync(string name)
        {
            return await _dbContext.Wines
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<bool> UpdateWineStockAsync(int id, int newStock)
        {
            var wine = await _dbContext.Wines.FindAsync(id);
            if (wine == null) return false;

            wine.Stock = newStock;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveWineAsync(int id)
        {
            var wine = await _dbContext.Wines.FindAsync(id);
            if (wine == null) return false;

            _dbContext.Wines.Remove(wine);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
