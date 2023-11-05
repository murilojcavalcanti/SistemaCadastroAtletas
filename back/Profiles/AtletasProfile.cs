using AutoMapper;
using back.Data.DTO.Atleta;
using back.Models;

namespace back.Profiles
{
    public class AtletasProfile :Profile
    {
        public AtletasProfile()
        {
            CreateMap<CadastraAtletaDTO, Atletas>();
            CreateMap<AtualizaAtletaDTO, Atletas>();
            CreateMap<Atletas, LeAtletaDTO>();
        }
    }
}
