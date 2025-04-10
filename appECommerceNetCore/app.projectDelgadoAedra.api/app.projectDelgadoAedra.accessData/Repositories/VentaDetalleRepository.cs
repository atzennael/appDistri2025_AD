using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.accessData.Context;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public class VentaDetalleRepository : crudGenericService<VentaDetalle>, IVentaDetalleRepository
    {
        public VentaDetalleRepository(appDbContext context) : base(context)
        {

        }

        public async Task<VentaDetalle> CreateVentaDetalle(VentaDetalle entity)
        {
            return await InsertEntity(entity);
        }

        public async Task DeleteVentaDetalle(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<VentaDetalle> GetVentaDetalle(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<VentaDetalle>> GetVentaDetalleLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateVentaDetalle(VentaDetalle entity)
        {
            await UpdateEntity(entity);
        }
    }
}
