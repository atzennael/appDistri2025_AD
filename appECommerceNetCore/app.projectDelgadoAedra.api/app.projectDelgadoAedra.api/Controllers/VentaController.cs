using app.projectDelgadoAedra.common.Request;
using app.projectDelgadoAedra_services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.projectDelgadoAedra.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {

        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hola Mundo -- Venta");
        }

        /**
         * API PARA OBTENER TODOS LAS VENTAS
         * */
        [HttpPost("obtenerVentas")]
        public async Task<IActionResult> ObtenerVentas()
        {
            var result = await _ventaService.GetVentaLista();
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
        * API PARA INSERTAR UNA VENTA
        * */
        [HttpPost("insertarVenta")]
        public async Task<IActionResult> PostSales([FromBody] VentaRequest request)
        {
            var response = await _ventaService.CrearVenta(request);
            return Ok(response);
        }

        /**
        * API PARA OBTENER UNA VENTA POR ID
        * */
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerVenta(int id)
        {
            var response = await _ventaService.GetVenta(id);
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
         * API PARA ACTUALIZAR UNA VENTA POR ID
         * */
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> ActualizarSales(int id, [FromBody] VentaRequest request)
        {
            var result = await _ventaService.ActualizarVenta(id, request);
            return Ok(result);
        }
        /**
         * API PARA ELIMINAR UNA VENTA POR ID
         * */
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarSales(int id)
        {
            var result = await _ventaService.EliminarVenta(id);
            return Ok(result);
        }

    }
}
