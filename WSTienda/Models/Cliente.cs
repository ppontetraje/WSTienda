using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WSTienda.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            CabeceraDetalle = new HashSet<CabeceraDetalle>();
        }

        public long IdCliente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<CabeceraDetalle> CabeceraDetalle { get; set; }
    }
}
