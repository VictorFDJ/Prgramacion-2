using CRUD.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Persitense
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producto>().HasIndex(c => c.Nombre).IsUnique();
        }
    }
}
