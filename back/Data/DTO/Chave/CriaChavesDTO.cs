using back.Enums;
using System.ComponentModel.DataAnnotations;

namespace back.Data.DTO.Chave{
    public class CriaChavesDTO
    {

        [Required]
        public int CampeonatoId { get; set; }

        [Required]
        public FaixaEnum Faixa { get; set; }

        [Required]
        public PesoEnum Peso { get; set; }

        [Required]
        public SexoEnum Sexo { get; set; }

    }
}
