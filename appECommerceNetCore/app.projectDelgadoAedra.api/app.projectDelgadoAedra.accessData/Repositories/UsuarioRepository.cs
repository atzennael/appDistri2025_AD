using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.accessData.Context;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public class UsuarioRepository : crudGenericService<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(appDbContext context) : base(context)
        {

        }

        public async Task<Usuario> CreateUsuario(Usuario entity)
        {
            return await InsertEntity(entity);
        }

        public async Task DeleteUsuario(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Usuario>> GetUsuarioLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateUsuario(Usuario entity)
        {
            await UpdateEntity(entity);
        }
    }
}
