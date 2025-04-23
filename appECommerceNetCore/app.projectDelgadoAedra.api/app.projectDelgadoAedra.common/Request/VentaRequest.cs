using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.common.Request
{
    public class VentaRequest
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Required(ErrorMessage = "El campo FechaVenta es obligatorio y/o el formato no es válido")]
        public DateTime FechaVenta { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? NumeroFactura { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? MetodoPago { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal TotalVenta { get; set; }
    }
}
