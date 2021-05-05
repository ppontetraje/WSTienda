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
                    using (var transaction = db.Database.BeginTransaction()) {
                        try
                        {
                            var cabeceraDetalle = new CabeceraDetalle();
                            cabeceraDetalle.Total = requestDTO.SaleDetails.Sum(d => d.Cantidad * d.PrecioActual);
                            cabeceraDetalle.IdCliente = requestDTO.IdCliente;
                            cabeceraDetalle.Fecha = DateTime.Now;
                            cabeceraDetalle.IdOrganizacion = requestDTO.IdOrganizacion;

                            db.CabeceraDetalle.Add(cabeceraDetalle);
                            db.SaveChanges();

                            foreach (var saleDetails in requestDTO.SaleDetails)
                            {
                                Detalle detalle = new Detalle();
                                detalle.Cantidad = saleDetails.Cantidad;
                                detalle.PrecioActual = saleDetails.PrecioActual;
                                detalle.PrecioTotal = cabeceraDetalle.Total;
                                detalle.IdProducto = saleDetails.IdProducto;
                                detalle.IdCabeceraDetalle = cabeceraDetalle.IdCabeceraDetalle;
                                db.Detalle.Add(detalle);
                                db.SaveChanges();
                            }

                            transaction.Commit();
                            response.Success = true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                        }
                    }
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
