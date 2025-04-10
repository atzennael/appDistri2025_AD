using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public interface IProductoRepository
    {
        Task<Producto> GetProducto(int id);
        Task<Producto> CreateProducto(Producto entity);
        Task<List<Producto>> GetProductoLista();
        Task UpdateProducto(Producto entity);
        Task DeleteProducto(int id);
    }
}
