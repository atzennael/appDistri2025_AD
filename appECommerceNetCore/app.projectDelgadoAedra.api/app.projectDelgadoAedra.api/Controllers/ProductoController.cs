using app.projectDelgadoAedra.common.Request;
using app.projectDelgadoAedra_services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.projectDelgadoAedra.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {

        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hola Mundo -- Producto");
        }

        /**
         * API PARA OBTENER TODOS LOS PRODUCTOS
         * */
        [HttpPost("obtenerProductos")]
        public async Task<IActionResult> ObtenerProductos()
        {
            var result = await _productoService.GetProductoLista();
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
        * API PARA INSERTAR UN PRODUCTO
        * */
        [HttpPost("insertarProducto")]
        public async Task<IActionResult> PostProducts([FromBody] ProductoRequest request)
        {
            var response = await _productoService.CrearProducto(request);
            return Ok(response);
        }

        /**
        * API PARA OBTENER UN PRODUCTO POR ID
        * */
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerProducto(int id)
        {
            var response = await _productoService.GetProducto(id);
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
         * API PARA ACTUALIZAR UN PRODUCTO POR ID
         * */
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> ActualizarProducts(int id, [FromBody] ProductoRequest request)
        {
            var result = await _productoService.ActualizarProducto(id, request);
            return Ok(result);
        }
        /**
         * API PARA ELIMINAR UN PRODUCTO POR ID
         * */
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarProducts(int id)
        {
            var result = await _productoService.EliminarProducto(id);
            return Ok(result);
        }

    }
}
