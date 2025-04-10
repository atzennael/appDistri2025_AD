using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.accessData.Context;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public class ClienteRepository : crudGenericService<Cliente>, IClienteRepository
    {
        public ClienteRepository(appDbContext context) : base(context)
        {

        }

        public async Task<Cliente> CreateCliente(Cliente entity)
        {
            return await InsertEntity(entity);
        }

        public async Task DeleteCliente(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Cliente>> GetClienteLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateCliente(Cliente entity)
        {
            await UpdateEntity(entity);
        }
    }
}
