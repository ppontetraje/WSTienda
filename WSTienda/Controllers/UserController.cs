using Microsoft.AspNetCore.Mvc;
using WSTienda.DTOs;
using WSTienda.Interfaces;
using WSTienda.Responses;

namespace WSTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] AuthRequestDTO authRequestDto)
        {
            BaseResponse response = new BaseResponse();
            
            var userResponse = _userService.Auth(authRequestDto);

            if(userResponse == null)
            {
                response.Message = "Incorrect data";
                return BadRequest(response);
            }
            response.Success = true;
            response.Data = userResponse;
            return Ok(response); 

        }
    }
}
