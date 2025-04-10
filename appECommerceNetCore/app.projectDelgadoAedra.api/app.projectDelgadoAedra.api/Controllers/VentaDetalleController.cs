using Microsoft.AspNetCore.Mvc;
using app.projectDelgadoAedra_services.Interfaces;
using app.projectDelgadoAedra.common.Request;

namespace app.projectDelgadoAedra.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaDetalleController : Controller
    {

        private readonly IVentaDetalleService _ventaDetalleService;

        public VentaDetalleController(IVentaDetalleService ventaDetalleService)
        {
            _ventaDetalleService = ventaDetalleService;
        }

        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hola Mundo -- Venta Detalle");
        }

        /**
         * API PARA OBTENER TODOS LAS VENTAS DETALLES
         * */
        [HttpPost("obtenerVentaDetalles")]
        public async Task<IActionResult> ObtenerVentaDetalles()
        {
            var result = await _ventaDetalleService.GetVentaDetalleLista();
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
        * API PARA INSERTAR UNA VENTA DETALLE
        * */
        [HttpPost("insertarVentaDetalle")]
        public async Task<IActionResult> PostDetails([FromBody] VentaDetalleRequest request)
        {
            var response = await _ventaDetalleService.CrearVentaDetalle(request);
            return Ok(response);
        }

        /**
        * API PARA OBTENER UNA VENTA POR ID
        * */
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerVentaDetalle(int id)
        {
            var response = await _ventaDetalleService.GetVentaDetalle(id);
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
         * API PARA ACTUALIZAR UNA VENTA DETALLE POR ID
         * */
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> ActualizarDetails(int id, [FromBody] VentaDetalleRequest request)
        {
            var result = await _ventaDetalleService.ActualizarVentaDetalle(id, request);
            return Ok(result);
        }
        /**
         * API PARA ELIMINAR UNA VENTA DETALLE POR ID
         * */
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarDetails(int id)
        {
            var result = await _ventaDetalleService.EliminarVentaDetalle(id);
            return Ok(result);
        }

    }
}
