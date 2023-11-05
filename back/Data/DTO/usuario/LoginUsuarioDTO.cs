using System.ComponentModel.DataAnnotations;

namespace back.Data.DTO.usuario
{
    public class LoginUsuarioDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
