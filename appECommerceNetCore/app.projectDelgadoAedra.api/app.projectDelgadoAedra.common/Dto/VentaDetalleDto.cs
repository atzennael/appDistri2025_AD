using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.entities;

namespace app.projectDelgadoAedra.common.Dto
{
    public class VentaDetalleDto
    {
        public int Id { get; set; }
        public string? VentaId { get; set; }

        public Venta? Venta { get; set; }

        public int NumeroItem { get; set; }

        public int ProductoId { get; set; }

        public Producto? Producto { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Total { get; set; }
    }
}
