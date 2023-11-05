using back.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace back.Services
{
    public class AuthorizationService
    {
        public string GeraToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim("tipoUsuario", usuario.TipoUsuario.ToString()),
                new Claim ("LoginTimeStamp", DateTime.UtcNow.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("D9pPYl57QYjcVsvFCdYdMZ0EkfYOrUgH"));

            var credencialSign = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(7),
                claims: claims,
                signingCredentials: credencialSign
                ); 
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
