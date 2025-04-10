using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.projectDelgadoAedra.common.Request
{
    public class UsuarioRequest
    {
        [Required(ErrorMessage = "El campo Correo no puede estar vacío")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El campo Clave no puede estar vacío")]
        public string? Clave { get; set; }
    }
}
