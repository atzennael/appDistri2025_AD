using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.common.Dto;
using app.projectDelgadoAedra.common.Request;

namespace app.projectDelgadoAedra_services.Interfaces
{
    public interface IUsuarioService
    {
        Task<BaseResponse<UsuarioDto>> GetUsuario(int id);

        Task<BaseResponse<List<UsuarioDto>>> GetUsuarioLista();

        Task<BaseResponse<UsuarioDto>> CrearUsuario(UsuarioRequest request);

        Task<BaseResponse<UsuarioDto>> ActualizarUsuario(int id, UsuarioRequest request);

        Task<BaseResponse<string>> EliminarUsuario(int id);
    }
}
