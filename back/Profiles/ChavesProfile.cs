using AutoMapper;
using back.Data.DTO.Chave;
using back.Models;

namespace back.Profiles
{
    public class ChavesProfile:Profile
    {
        public ChavesProfile()
        {
            CreateMap<CriaChavesDTO, Chaves>();
            CreateMap< Chaves,LeChave>().ForMember(chaveDto => chaveDto.Lutas,
                opt => opt.MapFrom(campDto => campDto.Lutas));
        }
    }
}
