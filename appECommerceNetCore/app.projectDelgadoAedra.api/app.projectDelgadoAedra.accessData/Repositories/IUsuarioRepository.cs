using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> CreateUsuario(Usuario entity);
        Task<List<Usuario>> GetUsuarioLista();
        Task UpdateUsuario(Usuario entity);
        Task DeleteUsuario(int id);
    }
}
