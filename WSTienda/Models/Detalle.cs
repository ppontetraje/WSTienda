using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WSTienda.Models
{
    public partial class Detalle
    {
        public long IdDetalle { get; set; }
        public decimal PrecioActual { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
        public bool? Activo { get; set; }
        public long IdCabeceraDetalle { get; set; }
        public long IdProducto { get; set; }

        public virtual CabeceraDetalle IdCabeceraDetalleNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
