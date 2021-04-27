using System.Linq;
using WSTienda.DTOs;
using WSTienda.Interfaces;
using WSTienda.Models;
using WSTienda.Responses;
using WSTienda.Tools;


namespace WSTienda.Services
{
    public class UserService : IUserService
    {
        public UserResponse Auth(AuthRequestDTO authRequestDTO)
        {
            UserResponse userResponse = new UserResponse();
            using (var db = new BDTiendaContext())
            {
                string password = Encrypt.GetSHA256(authRequestDTO.Password);

                var user = db.Usuario.Where(d => d.Email == authRequestDTO.Email
                && d.Contrasena == password).FirstOrDefault();
                if (user == null)
                    return null;

                userResponse.Email = user.Email;
            }
            return userResponse;
            
        }
    }
}
