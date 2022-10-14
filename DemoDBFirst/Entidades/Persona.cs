using System;
using System.Collections.Generic;

namespace DemoDBFirst.Entidades
{
    public partial class Persona
    {
        public int PersonaId { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public DateTime? Nacimiento { get; set; }
        public string? Email { get; set; }
    }
}
