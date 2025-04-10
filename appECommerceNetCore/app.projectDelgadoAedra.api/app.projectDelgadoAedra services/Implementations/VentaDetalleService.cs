using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.accessData.Repositories;
using app.projectDelgadoAedra.common.Dto;
using app.projectDelgadoAedra.common.Request;
using app.projectDelgadoAedra.entities;
using app.projectDelgadoAedra_services.Interfaces;

namespace app.projectDelgadoAedra_services.Implementations
{
    public class VentaDetalleService : IVentaDetalleService
    {
        private readonly IVentaDetalleRepository _repository;

        public VentaDetalleService(IVentaDetalleRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<VentaDetalleDto>> ActualizarVentaDetalle(int id, VentaDetalleRequest request)
        {
            var response = new BaseResponse<VentaDetalleDto>();
            try
            {
                VentaDetalle detalle = new();
                detalle.Id = id;
                detalle.VentaId = request.VentaId;
                detalle.Venta = request.Venta;
                detalle.NumeroItem = request.NumeroItem;
                detalle.ProductoId = request.ProductoId;
                detalle.Producto = request.Producto;
                detalle.PrecioUnitario = request.PrecioUnitario;
                detalle.Cantidad = request.Cantidad;
                detalle.Total = request.Total;
                detalle.Fecha = DateTime.Now;
                detalle.Estado = true;

                await _repository.UpdateVentaDetalle(detalle);

                response.Result = new VentaDetalleDto
                {
                    Id = detalle.Id,
                    VentaId = detalle.VentaId,
                    Venta = detalle.Venta,
                    NumeroItem = detalle.NumeroItem,
                    ProductoId = detalle.ProductoId,
                    Producto = detalle.Producto,
                    PrecioUnitario = detalle.PrecioUnitario,
                    Cantidad = detalle.Cantidad,
                    Total = detalle.Total,
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

        public async Task<BaseResponse<VentaDetalleDto>> CrearVentaDetalle(VentaDetalleRequest request)
        {
            var response = new BaseResponse<VentaDetalleDto>();
            try
            {
                VentaDetalle detalleEntity = new();

                detalleEntity.VentaId = request.VentaId;
                detalleEntity.Venta = request.Venta;
                detalleEntity.NumeroItem = request.NumeroItem;
                detalleEntity.ProductoId = request.ProductoId;
                detalleEntity.Producto = request.Producto;
                detalleEntity.PrecioUnitario = request.PrecioUnitario;
                detalleEntity.Cantidad = request.Cantidad;
                detalleEntity.Total = request.Total;
                detalleEntity.Fecha = DateTime.Now;
                detalleEntity.Estado = true;

                var detalle = await _repository.CreateVentaDetalle(detalleEntity);

                response.Result = new VentaDetalleDto
                {
                    Id = detalle.Id,
                    VentaId = detalle.VentaId,
                    Venta = detalle.Venta,
                    NumeroItem = detalle.NumeroItem,
                    ProductoId = detalle.ProductoId,
                    Producto = detalle.Producto,
                    PrecioUnitario = detalle.PrecioUnitario,
                    Cantidad = detalle.Cantidad,
                    Total = detalle.Total,
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

        public async Task<BaseResponse<string>> EliminarVentaDetalle(int id)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _repository.DeleteVentaDetalle(id);

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

        public async Task<BaseResponse<VentaDetalleDto>> GetVentaDetalle(int id)
        {
            var response = new BaseResponse<VentaDetalleDto>();
            try
            {
                var detalle = await _repository.GetVentaDetalle(id);
                if (detalle == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new VentaDetalleDto
                {
                    Id = detalle.Id,
                    VentaId = detalle.VentaId,
                    Venta = detalle.Venta,
                    NumeroItem = detalle.NumeroItem,
                    ProductoId = detalle.ProductoId,
                    Producto = detalle.Producto,
                    PrecioUnitario = detalle.PrecioUnitario,
                    Cantidad = detalle.Cantidad,
                    Total = detalle.Total,
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


        public async Task<BaseResponse<List<VentaDetalleDto>>> GetVentaDetalleLista()
        {
            var response = new BaseResponse<List<VentaDetalleDto>>();
            try
            {
                var result = await _repository.GetVentaDetalleLista();

                response.Result = result.Select(p => new VentaDetalleDto
                {
                    Id = p.Id,
                    VentaId = p.VentaId,
                    Venta = p.Venta,
                    NumeroItem = p.NumeroItem,
                    ProductoId = p.ProductoId,
                    Producto = p.Producto,
                    PrecioUnitario = p.PrecioUnitario,
                    Cantidad = p.Cantidad,
                    Total = p.Total,
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
