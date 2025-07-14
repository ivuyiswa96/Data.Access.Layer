using Data.Access.Layer.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.Access.Layer.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}
