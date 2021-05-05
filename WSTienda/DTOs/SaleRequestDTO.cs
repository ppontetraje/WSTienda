using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WSTienda.DTOs
{
    public class SaleRequestDTO
    {
        [Required]
        [CustomerExists(ErrorMessage = "El Cliente no Existe")]
        [Range(1, long.MaxValue, ErrorMessage ="El valor de IdCliente debe ser mayor que 0")]
        public long IdCliente { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Deben existir Detalles de la venta")]
        public List<SaleDetail> SaleDetails { get; set; }
        public SaleRequestDTO()
        {
            this.SaleDetails = new List<SaleDetail>();
        }
    }

    public class SaleDetail
    {
        public decimal Cantidad { get; set; }
        public decimal PrecioActual { get; set; }
        public decimal PrecioTotal { get; set; }
        public long IdProducto { get; set; }

    }

    #region Validations
    public class CustomerExistsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var idCliente = value;
            using(var db = new Models.BDTiendaContext())
            {
                if (db.Cliente.Find(idCliente) == null) return false;
            }
            return true;
        }
    }
    #endregion
}
