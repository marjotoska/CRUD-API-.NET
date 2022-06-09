global using Microsoft.EntityFrameworkCore;

namespace LearningCrudAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
    }
}
