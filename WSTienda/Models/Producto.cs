using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WSTienda.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detalle = new HashSet<Detalle>();
        }

        public long IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public bool? Activo { get; set; }
        public int IdTipoProducto { get; set; }

        public virtual TipoProducto IdTipoProductoNavigation { get; set; }
        public virtual ICollection<Detalle> Detalle { get; set; }
    }
}
