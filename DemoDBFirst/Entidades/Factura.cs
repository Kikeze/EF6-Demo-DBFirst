using System;
using System.Collections.Generic;

namespace DemoDBFirst.Entidades
{
    public partial class Factura
    {
        public Factura()
        {
            DesgloseDetalles = new HashSet<DesgloseDetalle>();
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int FacturaId { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Monto { get; set; }

        public virtual ICollection<DesgloseDetalle> DesgloseDetalles { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
