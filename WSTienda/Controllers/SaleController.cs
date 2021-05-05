using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTienda.DTOs;
using WSTienda.Interfaces;
using WSTienda.Models;
using WSTienda.Responses;
using WSTienda.Services;

namespace WSTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private ISaleService _sale;
        public SaleController(ISaleService sale)
        {
            _sale = sale;
        }
        [HttpPost]
        public IActionResult add(SaleRequestDTO model)
        {
             
            BaseResponse response = new BaseResponse();
            try
            {
                _sale.Add(model);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
