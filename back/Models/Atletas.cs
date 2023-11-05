using back.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Atletas: Usuario
    {
        public Atletas() : base(){ }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required]
        [DefaultValue(0)]
        public SexoEnum Sexo { get; set; }

        [Required]
        public string Equipe { get; set; }

        [Required]
        [DefaultValue(0)]
        public FaixaEnum Faixa { get; set; }

        [Required]
        [DefaultValue(0)]
        public PesoEnum Peso { get; set; }

        [Required]
        public DateTime DataInscricao { get
            {
                return DateTime.Now;
            } 
        }
        
        public ICollection<AtletaCampeonato> AtletaCampeonatos { get; set; }
        public ICollection<AtletasLutas> AtletasLutas { get; set; }
    }
}
