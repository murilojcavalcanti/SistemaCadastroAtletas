using back.Enums;
using Microsoft.AspNetCore.Authorization;

namespace back.Authorization
{
    public class TipoUsuario:IAuthorizationRequirement
    {
        public TipoUsuario(UsuarioEnum tipoUsuario)
        {
            this.tipoUsuario = tipoUsuario;
        }
        public UsuarioEnum tipoUsuario { get;}
    }
}
