using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTienda.DTOs;
using WSTienda.Interfaces;
using WSTienda.Models;

namespace WSTienda.Services
{
    public class SaleService : ISaleService
    {
        public void Add(SaleRequestDTO model)
        {
                using (BDTiendaContext db = new BDTiendaContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var cabeceraDetalle = new CabeceraDetalle();
                            cabeceraDetalle.Total = model.SaleDetails.Sum(d => d.Cantidad * d.PrecioActual);
                            cabeceraDetalle.IdCliente = model.IdCliente;
                            cabeceraDetalle.Fecha = DateTime.Now;
                            cabeceraDetalle.IdOrganizacion = 1;

                            db.CabeceraDetalle.Add(cabeceraDetalle);
                            db.SaveChanges();

                            foreach (var saleDetails in model.SaleDetails)
                            {
                                Detalle detalle = new Detalle();
                                detalle.Cantidad = saleDetails.Cantidad;
                                detalle.PrecioActual = saleDetails.PrecioActual;
                                detalle.PrecioTotal = saleDetails.PrecioActual * saleDetails.Cantidad;
                                detalle.IdProducto = saleDetails.IdProducto;
                                detalle.IdCabeceraDetalle = cabeceraDetalle.IdCabeceraDetalle;
                                db.Detalle.Add(detalle);
                                db.SaveChanges();
                            }

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw new Exception("Ocurrió un error en la Inserción");
                        }
                    }
                }
            }
        
    }
}
