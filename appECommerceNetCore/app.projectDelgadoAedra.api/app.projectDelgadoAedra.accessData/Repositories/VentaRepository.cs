using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.accessData.Context;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public class VentaRepository : crudGenericService<Venta>, IVentaRepository
    {
        public VentaRepository(appDbContext context) : base(context)
        {

        }

        public async Task<Venta> CreateVenta(Venta entity)
        {
            return await InsertEntity(entity);
        }

        public async Task DeleteVenta(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Venta> GetVenta(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Venta>> GetVentaLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateVenta(Venta entity)
        {
            await UpdateEntity(entity);
        }
    }
}
