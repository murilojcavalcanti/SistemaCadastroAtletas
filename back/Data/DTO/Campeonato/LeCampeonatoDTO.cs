using back.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using back.Models;
using back.Profiles;

namespace back.Data.DTO.Campeonato
{
    public class LeCampeonatoDTO
    {

        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Sobre { get; set; }

        public string Imagem { get; set; }

        public DateTime DataRequisicao {  get; set; }

        public string Local {  get; set; }
        
        public DateTime DataRealizacao { get; set; }

        public TipoCampeonatoEnum TipoCampeonato { get; set; }

        public string InformacoesGerais { get; set; }

        public string Ginásio { get; set; }
        public FasesCampeonatoEnum Fase { get; set; }

        public bool Status { get; set; }
        public decimal Entrada { get; set; }

        public ICollection<AtletaCampeonato> AtletaCampeonatos { get; set; }

        public ICollection<Chaves> Chaves { get; set; }

    }
}
