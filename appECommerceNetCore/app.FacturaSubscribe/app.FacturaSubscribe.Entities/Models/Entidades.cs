using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace app.FacturaSubscribe.Entities.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Email { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string? CedulaIdentidad { get; set; }

    }
    public class Producto 
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

        public decimal PrecioUnitario { get; set; }
    }
    public class Venta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public DateTime FechaVenta { get; set; }

        public string? NumeroFactura { get; set; }

        public string? MetodoPago { get; set; }

        public decimal TotalVenta { get; set; }

    }
    public class VentaDetalle
    {
        public int Id { get; set; }
        public string? VentaId { get; set; }
        //public Venta? Venta { get; set; }
        public int NumeroItem { get; set; }
        public int ProductoId { get; set; }
        //public Producto? Producto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string? Correo { get; set; }

        public string? Clave { get; set; }
    }

}
