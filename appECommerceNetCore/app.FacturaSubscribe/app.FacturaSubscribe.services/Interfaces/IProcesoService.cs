using System.Threading.Tasks;
using app.FacturaSubscribe.Entities.Models;

namespace app.FacturaSubscribe.services.Interfaces
{
    public interface IProcesoService
    {
        Task GuardarCategoriaAsync(Categoria categoria);
        Task GuardarClienteAsync (Cliente cliente);
        Task GuardarProductoAsync(Producto producto);
        Task GuardarVentaAsync(Venta venta);
        Task GuardarVentaDetalleAsync(VentaDetalle detalle);
        Task GuardarUsuarioAsync(Usuario usuario);
    }
}
