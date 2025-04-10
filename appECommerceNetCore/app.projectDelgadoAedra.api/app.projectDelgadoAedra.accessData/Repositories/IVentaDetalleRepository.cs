using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public interface IVentaDetalleRepository
    {
        Task<VentaDetalle> GetVentaDetalle(int id);
        Task<VentaDetalle> CreateVentaDetalle(VentaDetalle entity);
        Task<List<VentaDetalle>> GetVentaDetalleLista();
        Task UpdateVentaDetalle(VentaDetalle entity);
        Task DeleteVentaDetalle(int id);
    }
}
