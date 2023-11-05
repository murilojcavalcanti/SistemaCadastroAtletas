using AutoMapper;
using back.Data.DTO.usuario;
using back.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace back.Services
{

    public class UsuarioService
    {
        private IMapper Mapper;
        private UserManager<Usuario> UserManager;
        private SignInManager<Usuario> Sign;
        private AuthorizationService Authorization;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, 
            SignInManager<Usuario> signInManager,
            SignInManager<Usuario> sign,
            AuthorizationService authorization)
        {
            Mapper = mapper;
            UserManager = userManager;
            Sign = sign;
            Authorization = authorization;
        }


        public async Task Cadastra(CadastraUsuarioDTO DTO)
        {
            Usuario usuario = Mapper.Map<Usuario>(DTO);

            IdentityResult resultado = await UserManager.CreateAsync(usuario, DTO.Password);

            if (!resultado.Succeeded) throw new ApplicationException("Falha no cadastro de usuario");
        }
        public async Task<string> Login(LoginUsuarioDTO dto)
        {
            var resultado = await Sign.PasswordSignInAsync(dto.Username, dto.Password, true,false);

            if (!resultado.Succeeded) throw new ApplicationException("Usuario não cadastrado ou email ou senha invalidos");
            Usuario usuario = Sign.UserManager.Users.FirstOrDefault(usuario => usuario.UserName == dto.Username);
            var token = Authorization.GeraToken(usuario);
            return token;
        }
    }
}

























    /*
    public class UsuarioService
    {
        private IMapper Mapper;
        private UserManager<Usuario> UserManager;
        //private SignInManager<Usuario> Sign;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager)
        {
            Mapper = mapper;
            UserManager = userManager;
          //  Sign = sign;
        }
        public async Task CadastraUsuario(CadastraUsuarioDTO dto)
        {
            Usuario usuario = Mapper.Map<Usuario>(dto);
            IdentityResult resultado = await UserManager.CreateAsync(usuario, dto.Password);
            if (!resultado.Succeeded) throw new ApplicationException("Falha no cadastro de usuario");
        }


    }
}
    */