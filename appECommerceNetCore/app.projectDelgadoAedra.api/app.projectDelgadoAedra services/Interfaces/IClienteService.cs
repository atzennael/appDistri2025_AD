using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.common.Dto;
using app.projectDelgadoAedra.common.Request;

namespace app.projectDelgadoAedra_services.Interfaces
{
    public interface IClienteService
    {
        Task<BaseResponse<ClienteDto>> GetCliente(int id);

        Task<BaseResponse<List<ClienteDto>>> GetClienteLista();

        Task<BaseResponse<ClienteDto>> CrearCliente(ClienteRequest request);

        Task<BaseResponse<ClienteDto>> ActualizarCliente(int id, ClienteRequest request);

        Task<BaseResponse<string>> EliminarCliente(int id);
    }
}
