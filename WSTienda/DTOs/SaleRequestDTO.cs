using System.Collections.Generic;

namespace WSTienda.DTOs
{
    public class SaleRequestDTO
    {
        public int IdCliente { get; set; }
        public decimal Total { get; set; }
        public int IdOrganizacion { get; set; }
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
}
