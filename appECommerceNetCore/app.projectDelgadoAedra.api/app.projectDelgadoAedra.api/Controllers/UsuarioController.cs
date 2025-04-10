using app.projectDelgadoAedra_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using app.projectDelgadoAedra.common.Request;

namespace app.projectDelgadoAedra.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hola Mundo -- Usuario");
        }

        /**
         * API PARA OBTENER TODOS LOS USUARIOS
         * */
        [HttpPost("obtenerUsuarios")]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var result = await _usuarioService.GetUsuarioLista();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        /**
        * API PARA INSERTAR UN USUARIO
        * */
        [HttpPost("insertarUsuario")]
        public async Task<IActionResult> PostUsers([FromBody] UsuarioRequest request)
        {
            var response = await _usuarioService.CrearUsuario(request);
            return Ok(response);
        }

        /**
        * API PARA OBTENER UN USUARIO POR ID
        * */
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var response = await _usuarioService.GetUsuario(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        /**
         * API PARA ACTUALIZAR UN USUARIO POR ID
         * */
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> ActualizarUsers(int id, [FromBody] UsuarioRequest request)
        {
            var result = await _usuarioService.ActualizarUsuario(id, request);
            return Ok(result);
        }
        /**
         * API PARA ELIMINAR UN USUARIO POR ID
         * */
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarUsers(int id)
        {
            var result = await _usuarioService.EliminarUsuario(id);
            return Ok(result);
        }

    }
}
