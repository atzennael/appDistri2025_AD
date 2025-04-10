using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.common.Dto;
using app.projectDelgadoAedra.common.Request;

namespace app.projectDelgadoAedra_services.Interfaces
{
    public interface ICategoriaService
    {
        Task<BaseResponse<CategoriaDto>> GetCategoria(int id);

        Task<BaseResponse<List<CategoriaDto>>> GetCategoriaLista();

        Task<BaseResponse<CategoriaDto>> CrearCategoria(CategoriaRequest request);

        Task<BaseResponse<CategoriaDto>> ActualizarCategoria(int id, CategoriaRequest request);

        Task<BaseResponse<string>> EliminarCategoria(int id);
    }
}
