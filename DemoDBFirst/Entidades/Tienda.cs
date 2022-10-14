using System;
using System.Collections.Generic;

namespace DemoDBFirst.Entidades
{
    public partial class Tienda
    {
        public Tienda()
        {
            InversePadre = new HashSet<Tienda>();
        }

        public int TiendaId { get; set; }
        public string? Nombre { get; set; }
        public string? Rfc { get; set; }
        public DateTime? Apertura { get; set; }
        public int? PadreId { get; set; }

        public virtual Tienda? Padre { get; set; }
        public virtual ICollection<Tienda> InversePadre { get; set; }
    }
}
