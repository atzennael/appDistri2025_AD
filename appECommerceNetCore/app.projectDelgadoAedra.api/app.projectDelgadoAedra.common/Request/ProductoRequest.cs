using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.common.Request
{
    public class ProductoRequest
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [StringLength(50, ErrorMessage = "El campo no debe ser mayor a 50 carácteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo CategoriaId es obligatorio")]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Formato no válido")]
        public Categoria? Categoria { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal PrecioUnitario { get; set; }
    }
}
