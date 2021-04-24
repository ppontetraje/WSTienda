using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WSTienda.Models
{
    public partial class CabeceraDetalle
    {
        public CabeceraDetalle()
        {
            Detalle = new HashSet<Detalle>();
        }

        public long IdCabeceraDetalle { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool? Activo { get; set; }
        public int IdOrganizacion { get; set; }
        public long IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Organizacion IdOrganizacionNavigation { get; set; }
        public virtual ICollection<Detalle> Detalle { get; set; }
    }
}
