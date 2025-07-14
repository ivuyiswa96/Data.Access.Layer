using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Data.Access.Layer.DAL;

namespace Data.Access.Layer.Config
{
    internal class DbContextFactory
    {
        public static DataContext CreateDbContext()
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");


            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}
