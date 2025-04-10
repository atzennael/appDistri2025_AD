using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.common.Dto;
using app.projectDelgadoAedra.common.Request;

namespace app.projectDelgadoAedra_services.Interfaces
{
    public interface IVentaService
    {
        Task<BaseResponse<VentaDto>> GetVenta(int id);

        Task<BaseResponse<List<VentaDto>>> GetVentaLista();

        Task<BaseResponse<VentaDto>> CrearVenta(VentaRequest request);

        Task<BaseResponse<VentaDto>> ActualizarVenta(int id, VentaRequest request);

        Task<BaseResponse<string>> EliminarVenta(int id);
    }
}
