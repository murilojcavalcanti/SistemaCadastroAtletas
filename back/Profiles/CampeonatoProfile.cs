using AutoMapper;
using back.Data.DTO.Campeonato;
using back.Models;

namespace back.Profiles
{
    public class CampeonatoProfile:Profile
    {
        public CampeonatoProfile()
        {
            CreateMap<CriaCampeonatoDTO, Campeonatos>();
            CreateMap<Campeonatos, LeCampeonatoDTO>().ForMember(campDto => campDto.AtletaCampeonatos,
                opt => opt.MapFrom(campDto => campDto.AtletaCampeonatos)).ForMember(campDto => campDto.Chaves,
                opt => opt.MapFrom(campDto => campDto.Chaves));
            CreateMap<AtualizaCampeonatoDTO, Campeonatos>();
        }
    }
}
