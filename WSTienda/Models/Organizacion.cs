using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WSTienda.Models
{
    public partial class Organizacion
    {
        public Organizacion()
        {
            CabeceraDetalle = new HashSet<CabeceraDetalle>();
        }

        public int IdOrganizacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<CabeceraDetalle> CabeceraDetalle { get; set; }
    }
}
