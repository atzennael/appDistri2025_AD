using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.accessData.Context;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public class ProductoRepository : crudGenericService<Producto>, IProductoRepository
    {
        public ProductoRepository(appDbContext context) : base(context)
        {

        }

        public async Task<Producto> CreateProducto(Producto entity)
        {
            return await InsertEntity(entity);
        }

        public async Task DeleteProducto(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Producto>> GetProductoLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateProducto(Producto entity)
        {
            await UpdateEntity(entity);
        }
    }
}
