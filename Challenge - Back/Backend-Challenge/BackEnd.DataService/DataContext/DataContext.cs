using BackEnd.DataService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BackEnd.DataService.DataContext
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Clientes> Clientes { get; set; }

        public static DataContext GetNewDataContext(IConfiguration configuration)
        {
            return new DataContext(configuration);
        }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging()
                          .EnableDetailedErrors()
                          .UseSqlServer(_configuration.GetConnectionString("Database"), opts => opts.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null));
        }
    }
}
