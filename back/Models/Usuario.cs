using back.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [DefaultValue(0)]
        public UsuarioEnum TipoUsuario { get; set; }
     
        public Usuario() : base() { }        
    }
}
