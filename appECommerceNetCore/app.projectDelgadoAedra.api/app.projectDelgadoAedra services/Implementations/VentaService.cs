using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.accessData.Repositories;
using app.projectDelgadoAedra.common.Dto;
using app.projectDelgadoAedra.common.Request;
using app.projectDelgadoAedra.entities;
using app.projectDelgadoAedra_services.EventMQ;
using app.projectDelgadoAedra_services.Interfaces;

namespace app.projectDelgadoAedra_services.Implementations
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _repository;
        private readonly IRabbitMQService _rabbitMQService;

        public VentaService(IVentaRepository repository, IRabbitMQService rabbitMQService)
        {
            _repository = repository;
            _rabbitMQService = rabbitMQService;
        }

        public async Task<BaseResponse<VentaDto>> ActualizarVenta(int id, VentaRequest request)
        {
            var response = new BaseResponse<VentaDto>();
            try
            {
                Venta venta = new();
                venta.Id = id;
                venta.ClienteId = request.ClienteId;
                //venta.Cliente = request.Cliente;
                venta.FechaVenta = request.FechaVenta;
                venta.NumeroFactura = request.NumeroFactura;
                venta.MetodoPago = request.MetodoPago;
                venta.TotalVenta = request.TotalVenta;
                venta.Fecha = DateTime.Now;
                venta.Estado = true;

                await _repository.UpdateVenta(venta);

                response.Result = new VentaDto
                {
                    Id = venta.Id,
                    ClienteId = venta.ClienteId,
                    Cliente =  venta.Cliente,
                    FechaVenta = venta.FechaVenta,
                    NumeroFactura = venta.NumeroFactura,
                    MetodoPago = venta.MetodoPago,
                    TotalVenta = venta.TotalVenta
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<VentaDto>> CrearVenta(VentaRequest request)
        {
            var response = new BaseResponse<VentaDto>();
            try
            {
                Venta ventaEntity = new();
                
                ventaEntity.ClienteId = request.ClienteId;
                //ventaEntity.Cliente = request.Cliente;
                ventaEntity.FechaVenta = request.FechaVenta;
                ventaEntity.NumeroFactura = request.NumeroFactura;
                ventaEntity.MetodoPago = request.MetodoPago;
                ventaEntity.TotalVenta = request.TotalVenta;
                ventaEntity.Fecha = DateTime.Now;
                ventaEntity.Estado = true;

                var venta = await _repository.CreateVenta(ventaEntity);

                response.Result = new VentaDto
                {
                    Id = venta.Id,
                    ClienteId = venta.ClienteId,
                    Cliente = venta.Cliente,
                    FechaVenta = venta.FechaVenta,
                    NumeroFactura = venta.NumeroFactura,
                    MetodoPago = venta.MetodoPago,
                    TotalVenta = venta.TotalVenta
                };

                response.Success = true;
                await _rabbitMQService.PublishMessage(response.Result, "ventasQueue");
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<string>> EliminarVenta(int id)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _repository.DeleteVenta(id);

                response.Result = "OK";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<VentaDto>> GetVenta(int id)
        {
            var response = new BaseResponse<VentaDto>();
            try
            {
                var venta = await _repository.GetVenta(id);
                if (venta == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new VentaDto
                {
                    Id = venta.Id,
                    ClienteId = venta.ClienteId,
                    Cliente = venta.Cliente,
                    FechaVenta = venta.FechaVenta,
                    NumeroFactura = venta.NumeroFactura,
                    MetodoPago = venta.MetodoPago,
                    TotalVenta = venta.TotalVenta
                };

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public async Task<BaseResponse<List<VentaDto>>> GetVentaLista()
        {
            var response = new BaseResponse<List<VentaDto>>();
            try
            {
                var result = await _repository.GetVentaLista();

                response.Result = result.Select(p => new VentaDto
                {
                    Id = p.Id,
                    ClienteId = p.ClienteId,
                    Cliente = p.Cliente,
                    FechaVenta = p.FechaVenta,
                    NumeroFactura = p.NumeroFactura,
                    MetodoPago = p.MetodoPago,
                    TotalVenta = p.TotalVenta
                }).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
