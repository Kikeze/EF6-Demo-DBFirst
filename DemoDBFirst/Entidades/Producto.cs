using System;
using System.Collections.Generic;

namespace DemoDBFirst.Entidades
{
    public partial class Producto
    {
        public Producto()
        {
            DesgloseDetalles = new HashSet<DesgloseDetalle>();
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public double? Precio { get; set; }

        public virtual ICollection<DesgloseDetalle> DesgloseDetalles { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
