using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WSTienda.DTOs;
using WSTienda.Interfaces;
using WSTienda.Models;
using WSTienda.Models.Common;
using WSTienda.Responses;
using WSTienda.Tools;


namespace WSTienda.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;

        }
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
                userResponse.Token = GetToken(user);
            }
            return userResponse;
            
        }

        private string GetToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Email, user.Email.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
