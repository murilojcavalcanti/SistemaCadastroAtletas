using back.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace back.Data.DTO.Campeonato
{
    public class AtualizaCampeonatoDTO
    {
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
        [StringLength(2)]
        public string Estado { get; set; }

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


    }
}
