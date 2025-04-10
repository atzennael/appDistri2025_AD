using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.accessData.Context;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public class CategoriaRepository : crudGenericService<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(appDbContext context) : base(context)
        {

        }

        public async Task<Categoria> CreateCategoria(Categoria entity)
        {
            return await InsertEntity(entity);
        }

        public async Task DeleteCategoria(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Categoria>> GetCategoriaLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateCategoria(Categoria entity)
        {
            await UpdateEntity(entity);
        }
    }
}
