using System;
using System.Collections.Generic;

namespace DemoDBFirst.Entidades
{
    public partial class DesgloseDetalle
    {
        public int DesgloseId { get; set; }
        public int? DetalleId { get; set; }
        public int? FacturaId { get; set; }
        public int? ProductoId { get; set; }
        public int? Piezas { get; set; }
        public string? Color { get; set; }
        public string? Forma { get; set; }
        public string? Leyenda { get; set; }

        public virtual DetalleFactura? Detalle { get; set; }
        public virtual Factura? Factura { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
