using app.FacturaSubscribe.DataAccess.Context;
using app.FacturaSubscribe.Entities.Models;
using app.FacturaSubscribe.services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.FacturaSubscribe.services.Implementacion
{
    public class ProcesoService : IProcesoService
    {
        private readonly AppDbContext _context;

        public ProcesoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task GuardarCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.Entry(categoria).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task GuardarClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.Entry(cliente).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task GuardarProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.Entry(producto).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task GuardarVentaAsync(Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.Entry(venta).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task GuardarVentaDetalleAsync(VentaDetalle detalle)
        {
            _context.VentaDetalles.Add(detalle);
            _context.Entry(detalle).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task GuardarUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.Entry(usuario).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

    }
}
