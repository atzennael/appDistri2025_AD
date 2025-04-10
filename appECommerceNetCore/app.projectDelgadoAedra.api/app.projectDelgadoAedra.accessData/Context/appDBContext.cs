using Microsoft.EntityFrameworkCore;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Context
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
