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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<UsuarioDto>> ActualizarUsuario(int id, UsuarioRequest request)
        {
            var response = new BaseResponse<UsuarioDto>();
            try
            {
                Usuario usuario = new();
                usuario.Id = id;
                usuario.Correo = request.Correo;
                usuario.Clave = request.Clave;
                usuario.Fecha = DateTime.Now;
                usuario.Estado = true;

                await _repository.UpdateUsuario(usuario);

                response.Result = new UsuarioDto
                {
                    Id = usuario.Id,
                    Correo = usuario.Correo,
                    Clave = usuario.Clave,
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

        public async Task<BaseResponse<UsuarioDto>> CrearUsuario(UsuarioRequest request)
        {
            var response = new BaseResponse<UsuarioDto>();
            try
            {
                Usuario usuarioEntity = new();
                usuarioEntity.Correo = request.Correo;
                usuarioEntity.Clave = request.Clave;
                usuarioEntity.Fecha = DateTime.Now;
                usuarioEntity.Estado = true;

                var usuario = await _repository.CreateUsuario(usuarioEntity);

                response.Result = new UsuarioDto
                {
                    Id = usuario.Id,
                    Correo = usuario.Correo,
                    Clave = usuario.Clave,
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

        public async Task<BaseResponse<string>> EliminarUsuario(int id)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _repository.DeleteUsuario(id);

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

        public async Task<BaseResponse<UsuarioDto>> GetUsuario(int id)
        {
            var response = new BaseResponse<UsuarioDto>();
            try
            {
                var usuario = await _repository.GetUsuario(id);
                if (usuario == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new UsuarioDto
                {
                    Id = usuario.Id,
                    Correo = usuario.Correo,
                    Clave = usuario.Clave,
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
        public async Task<BaseResponse<List<UsuarioDto>>> GetUsuarioLista()
        {
            var response = new BaseResponse<List<UsuarioDto>>();
            try
            {
                var result = await _repository.GetUsuarioLista();

                response.Result = result.Select(p => new UsuarioDto
                {
                    Id = p.Id,
                    Correo = p.Correo,
                    Clave = p.Clave
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
