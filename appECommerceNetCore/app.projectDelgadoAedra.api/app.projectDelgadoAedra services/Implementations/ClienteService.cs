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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<ClienteDto>> ActualizarCliente(int id, ClienteRequest request)
        {
            var response = new BaseResponse<ClienteDto>();
            try
            {
                Cliente cliente = new();
                cliente.Id = id;
                cliente.Nombre = request.Nombre;
                cliente.Apellido = request.Apellido;
                cliente.Email = request.Email;
                cliente.FechaNacimiento = request.FechaNacimiento;
                cliente.CedulaIdentidad = request.CedulaIdentidad;
                cliente.Fecha = DateTime.Now;
                cliente.Estado = true;

                await _repository.UpdateCliente(cliente);

                response.Result = new ClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    FechaNacimiento=cliente.FechaNacimiento,
                    CedulaIdentidad=cliente.CedulaIdentidad,
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

        public async Task<BaseResponse<ClienteDto>> CrearCliente(ClienteRequest request)
        {
            var response = new BaseResponse<ClienteDto>();
            try
            {
                Cliente clientEntity = new();
                clientEntity.Nombre = request.Nombre;
                clientEntity.Apellido = request.Apellido;
                clientEntity.Email = request.Email;
                clientEntity.FechaNacimiento = request.FechaNacimiento;
                clientEntity.CedulaIdentidad = request.CedulaIdentidad;
                clientEntity.Fecha = DateTime.Now;
                clientEntity.Estado = true;

                var cliente = await _repository.CreateCliente(clientEntity);

                response.Result = new ClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    FechaNacimiento = cliente.FechaNacimiento,
                    CedulaIdentidad = cliente.CedulaIdentidad,
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

        public async Task<BaseResponse<string>> EliminarCliente(int id)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _repository.DeleteCliente(id);

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

        public async Task<BaseResponse<ClienteDto>> GetCliente(int id)
        {
            var response = new BaseResponse<ClienteDto>();
            try
            {
                var cliente = await _repository.GetCliente(id);
                if (cliente == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new ClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    FechaNacimiento = cliente.FechaNacimiento,
                    CedulaIdentidad = cliente.CedulaIdentidad,
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


        public async Task<BaseResponse<List<ClienteDto>>> GetClienteLista()
        {
            var response = new BaseResponse<List<ClienteDto>>();
            try
            {
                var result = await _repository.GetClienteLista();

                response.Result = result.Select(p => new ClienteDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Email = p.Email,
                    FechaNacimiento = p.FechaNacimiento,
                    CedulaIdentidad = p.CedulaIdentidad
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
