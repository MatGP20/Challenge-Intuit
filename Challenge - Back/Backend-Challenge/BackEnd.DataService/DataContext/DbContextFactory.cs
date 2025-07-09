using Microsoft.Extensions.Configuration;

namespace BackEnd.DataService.DataContext
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IConfiguration _configuration;

        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataContext GetNewInstance()
        {
            return DataContext.GetNewDataContext(_configuration);
        }
    }
}
