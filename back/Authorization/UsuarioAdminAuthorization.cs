using back.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace back.Authorization
{
    public class UsuarioAdminAuthorization : AuthorizationHandler<TipoUsuario>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TipoUsuario requirement)
        {
            var tipoUsuarioClaim = context.User.FindFirst(claim =>claim.Type =="tipoUsuario");

            var tipoUsuario = tipoUsuarioClaim.Value;

            if ( tipoUsuario == UsuarioEnum.Admin.ToString())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
