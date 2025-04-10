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
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<ProductoDto>> ActualizarProducto(int id, ProductoRequest request)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                Producto producto = new();
                producto.Id = id;
                producto.Nombre = request.Nombre;
                producto.Descripcion = request.Descripcion;
                producto.CategoriaId = request.CategoriaId;
                producto.Categoria = request.Categoria;
                producto.PrecioUnitario = request.PrecioUnitario;
                producto.Fecha = DateTime.Now;
                producto.Estado = true;

                await _repository.UpdateProducto(producto);

                response.Result = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    CategoriaId = producto.CategoriaId,
                    Categoria = producto.Categoria,
                    PrecioUnitario = producto.PrecioUnitario,
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

        public async Task<BaseResponse<ProductoDto>> CrearProducto(ProductoRequest request)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                Producto productoEntity = new();
                productoEntity.Nombre = request.Nombre;
                productoEntity.Descripcion = request.Descripcion;
                productoEntity.CategoriaId = request.CategoriaId;
                productoEntity.PrecioUnitario = request.PrecioUnitario;
                productoEntity.Fecha = DateTime.Now;
                productoEntity.Estado = true;

                var producto = await _repository.CreateProducto(productoEntity);

                response.Result = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    CategoriaId = producto.CategoriaId,
                    Categoria = producto.Categoria,
                    PrecioUnitario = producto.PrecioUnitario,
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

        public async Task<BaseResponse<string>> EliminarProducto(int id)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _repository.DeleteProducto(id);

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

        public async Task<BaseResponse<ProductoDto>> GetProducto(int id)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                var producto = await _repository.GetProducto(id);
                if (producto == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    CategoriaId = producto.CategoriaId,
                    Categoria = producto.Categoria,
                    PrecioUnitario = producto.PrecioUnitario,
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


        public async Task<BaseResponse<List<ProductoDto>>> GetProductoLista()
        {
            var response = new BaseResponse<List<ProductoDto>>();
            try
            {
                var result = await _repository.GetProductoLista();

                response.Result = result.Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    CategoriaId = p.CategoriaId,
                    Categoria = p.Categoria,
                    PrecioUnitario = p.PrecioUnitario,
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
