using Microsoft.EntityFrameworkCore;
using VinotecaBackend.Entities;

namespace VinotecaBackend.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
        public DbSet<Wine> Wines { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
