using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTienda.DTOs;
using WSTienda.Models;
using WSTienda.Responses;

namespace WSTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        public IActionResult add(SaleRequestDTO requestDTO)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                using(BDTiendaContext db = new BDTiendaContext())
                {
                    var cabeceraDetalle = new CabeceraDetalle();
                    cabeceraDetalle.Total = requestDTO.Total;
                    cabeceraDetalle.IdCliente = requestDTO.IdCliente;
                    cabeceraDetalle.Fecha = DateTime.Now;
                    cabeceraDetalle.IdOrganizacion = requestDTO.IdOrganizacion;

                    db.CabeceraDetalle.Add(cabeceraDetalle);
                    db.SaveChanges();
                    foreach(var saleDetails in requestDTO.SaleDetails)
                    {
                        Detalle detalle = new Detalle();
                        detalle.Cantidad = saleDetails.Cantidad;
                        detalle.PrecioActual = saleDetails.PrecioActual;
                        detalle.PrecioTotal = saleDetails.PrecioTotal;
                        detalle.IdProducto = saleDetails.IdProducto;
                        detalle.IdCabeceraDetalle = cabeceraDetalle.IdCabeceraDetalle;
                        db.Detalle.Add(detalle);
                        db.SaveChanges();
                    }
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
