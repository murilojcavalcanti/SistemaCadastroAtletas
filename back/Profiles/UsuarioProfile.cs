using AutoMapper;
using back.Data.DTO.usuario;
using back.Models;

namespace back.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CadastraUsuarioDTO, Usuario>();

    }
}
