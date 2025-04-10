using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.accessData.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> GetCategoria(int id);
        Task<Categoria> CreateCategoria(Categoria entity);
        Task<List<Categoria>> GetCategoriaLista();
        Task UpdateCategoria(Categoria entity);
        Task DeleteCategoria(int id);
    }
}
