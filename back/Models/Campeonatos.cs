using back.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace back.Models
{
    public class Campeonatos
    {
        

        [Key]
        [Required]
        public int Id { get; set; }
   
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Required]
        public string Sobre { get; set; }

        [Required]
        public string Imagem { get; set; }

        [Required]
        public DateTime DataRequisicao
        {
            get
            {
                return DateTime.Now;
            }            
        }

        [Required]
        [StringLength(50)]
        public string Cidade { get; set; }
        [Required]
        public EstadoEnum Estado { get; set; }

        public string Local
        {
            get
            {
                return $"{Cidade} {Estado}";
            }
            set
            {
                var partes = value.Split(' ');
                if (partes.Length == 2)
                {
                    Cidade = partes[0];
                    Estado = (EstadoEnum)Enum.Parse(typeof(EstadoEnum), partes[1]); ;
                }
            }
        }
        [Required]
        public DateTime DataRealizacao { get; set; }

        [Required]
        public TipoCampeonatoEnum TipoCampeonato { get; set; }

        [Required]
        public string InformacoesGerais { get; set; }

        [Required]
        [StringLength(50)]
        public string Ginásio { get; set; }

        [Required]
        [DefaultValue(0)]
        public FasesCampeonatoEnum Fase { get; set; }

        [Required]
        [DefaultValue(1)]
        public bool Status { get; set; }

        public decimal Entrada { get; set; }

        public ICollection<AtletaCampeonato> AtletaCampeonatos { get; set; }
        
        public ICollection<Chaves> Chaves { get; set; }

    }
}
