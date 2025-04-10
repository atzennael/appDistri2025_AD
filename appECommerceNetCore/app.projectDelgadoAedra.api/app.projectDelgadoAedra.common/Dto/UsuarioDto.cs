﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.projectDelgadoAedra.common.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
    }
}
