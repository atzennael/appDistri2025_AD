using app.projectDelgadoAedra.common.Request;
using app.projectDelgadoAedra_services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.projectDelgadoAedra.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hola Mundo -- Cliente");
        }

        /**
         * API PARA OBTENER TODOS LOS CLIENTES
         * */
        [HttpPost("obtenerClientes")]
        public async Task<IActionResult> ObtenerClientes()
        {
            var result = await _clienteService.GetClienteLista();
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
        * API PARA INSERTAR UN CLIENTE
        * */
        [HttpPost("insertarCliente")]
        public async Task<IActionResult> PostClients([FromBody] ClienteRequest request)
        {
            var response = await _clienteService.CrearCliente(request);
            return Ok(response);
        }

        /**
        * API PARA OBTENER UNA CLIENTE POR ID
        * */
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerCliente(int id)
        {
            var response = await _clienteService.GetCliente(id);
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
         * API PARA ACTUALIZAR UN CLIENTE POR ID
         * */
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> ActualizarClients(int id, [FromBody] ClienteRequest request)
        {
            var result = await _clienteService.ActualizarCliente(id, request);
            return Ok(result);
        }
        /**
         * API PARA ELIMINAR UN CLIENTE POR ID
         * */
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarClients(int id)
        {
            var result = await _clienteService.EliminarCliente(id);
            return Ok(result);
        }

    }
}
