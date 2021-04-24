using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTienda.Features.Customer.Queries.GetCustomerList;
using WSTienda.Models;
using WSTienda.Responses;

namespace WSTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var oRespuesta = new BaseResponse();

            try
            {
                using (BDTiendaContext bd = new BDTiendaContext())
                {
                    var lst = bd.Cliente.ToList();
                    oRespuesta.Success = true;
                    oRespuesta.Data = lst;
                }
            }
            catch(Exception ex)
            {
                oRespuesta.Message = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpPost]
        public IActionResult Add(CustomerListVm oCustomerVm)
        {
            var oRespuesta = new BaseResponse();
            try
            {
                using (var db = new BDTiendaContext())
                {
                    var oCustomer = new Cliente();
                    oCustomer.Nombre = oCustomerVm.Nombre;
                    oCustomer.ApellidoPaterno = oCustomerVm.ApellidoPaterno;
                    oCustomer.ApellidoMaterno = oCustomerVm.ApellidoMaterno;
                    oCustomer.Dni = oCustomerVm.Dni;

                    db.Cliente.Add(oCustomer);
                    db.SaveChanges();
                    oRespuesta.Success = true;
                }

                 
            }
            catch(Exception ex)
            {
                oRespuesta.Message = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpPut]
        public IActionResult Update(CustomerListVm oCustomerVm)
        {
            var oRespuesta = new BaseResponse();
            try
            {
                using (var db = new BDTiendaContext())
                {
                    var oCustomer = db.Cliente.Find(oCustomerVm.IdCliente);
                    oCustomer.Nombre = oCustomerVm.Nombre;
                    oCustomer.ApellidoPaterno = oCustomerVm.ApellidoPaterno;
                    oCustomer.ApellidoMaterno = oCustomerVm.ApellidoMaterno;
                    oCustomer.Dni = oCustomerVm.Dni;

                    db.Entry(oCustomer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Success = true;
                }


            }
            catch (Exception ex)
            {
                oRespuesta.Message = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpDelete("{id}")]
        public IActionResult delete(long id)
        {
            var oRespuesta = new BaseResponse();
            try
            {
                using (var db = new BDTiendaContext())
                {
                    Cliente oCustomer = db.Cliente.Find(id);
                    db.Remove(oCustomer);
                    //db.SaveChanges();
                    oRespuesta.Success = true;
                }


            }
            catch (Exception ex)
            {
                oRespuesta.Message = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
