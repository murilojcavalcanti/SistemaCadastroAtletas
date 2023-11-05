using back.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace back.Data.DTO.Atleta
{
    public class LeAtletaDTO
    {

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string CPF { get; set; }

        public SexoEnum Sexo { get; set; }

        public string Equipe { get; set; }

        public FaixaEnum Faixa { get; set; }

        public PesoEnum Peso { get; set; }

         public DateTime DataInscricao { get;set;}
    }
}
