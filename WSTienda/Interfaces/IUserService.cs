using WSTienda.DTOs;
using WSTienda.Responses;

namespace WSTienda.Interfaces
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequestDTO authRequestDTO); 
    }
}
