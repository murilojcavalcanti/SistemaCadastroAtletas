using back.Enums;
using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Chaves
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public FaixaEnum Faixa { get; set; }

        [Required]
        public PesoEnum Peso { get; set; }

        [Required]
        public SexoEnum Sexo { get; set; }

        [Required]
        public int CampeonatoId { get; set; }

        public virtual Campeonatos Campeonato { get; set; }

        public virtual ICollection<Lutas> Lutas { get; set; }


    }
}
