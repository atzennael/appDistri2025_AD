using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetCliente(int id);
        Task<Cliente> CreateCliente(Cliente entity);
        Task<List<Cliente>> GetClienteLista();
        Task UpdateCliente(Cliente entity);
        Task DeleteCliente(int id);
    }
}
