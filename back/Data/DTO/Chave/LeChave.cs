using back.Enums;
using back.Models;

namespace back.Data.DTO.Chave
{
    public class LeChave
    {
        public int Id { get; set; }

        public FaixaEnum Faixa { get; set; }

        public PesoEnum Peso { get; set; }

        public SexoEnum Sexo { get; set; }

        public int CampeonatoId { get; set; }

        public virtual Campeonatos Campeonato { get; set; }

        public virtual ICollection<Lutas> Lutas { get; set; }

    }
}
