using back.Enums;
using System.ComponentModel.DataAnnotations;

namespace back.Data.DTO.usuario
{
    public class CadastraUsuarioDTO
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
        
        public UsuarioEnum categoriaUsuario { get; set; }

    }
}
