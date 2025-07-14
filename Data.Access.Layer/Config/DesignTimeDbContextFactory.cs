using Data.Access.Layer.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Data.Access.Layer.Config
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            var connStr = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connStr);

            return new DataContext(optionsBuilder.Options);
        }
    }
}
