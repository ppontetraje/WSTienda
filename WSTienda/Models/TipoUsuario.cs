using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WSTienda.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string TipoUsuario1 { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
