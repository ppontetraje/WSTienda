using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WSTienda.Models
{
    public partial class TipoProducto
    {
        public TipoProducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdTipoProducto { get; set; }
        public string TipoProducto1 { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
