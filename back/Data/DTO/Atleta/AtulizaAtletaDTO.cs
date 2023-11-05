using back.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace back.Data.DTO.Atleta
{
    public class AtualizaAtletaDTO
    {
        public string Nome { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string RePassword { get; set; }

        public string CPF { get; set; }

        public SexoEnum Sexo { get; set; }

        public string Equipe { get; set; }

        public FaixaEnum Faixa { get; set; }

        public PesoEnum Peso { get; set; }

    }
}
