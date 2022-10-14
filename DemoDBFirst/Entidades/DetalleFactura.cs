using System;
using System.Collections.Generic;

namespace DemoDBFirst.Entidades
{
    public partial class DetalleFactura
    {
        public DetalleFactura()
        {
            DesgloseDetalles = new HashSet<DesgloseDetalle>();
        }

        public int DetalleId { get; set; }
        public int? FacturaId { get; set; }
        public int? ProductoId { get; set; }
        public double? Precio { get; set; }
        public int? Cantidad { get; set; }

        public virtual Factura? Factura { get; set; }
        public virtual Producto? Producto { get; set; }
        public virtual ICollection<DesgloseDetalle> DesgloseDetalles { get; set; }
    }
}
