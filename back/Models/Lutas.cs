using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class Lutas
    {
        [Key]
        public int Id { get; set; }

        public ICollection<AtletasLutas> AtletasLutas { get; set; }

        [Required]
        public int ChavesId { get; set; }

        public virtual Chaves Chave { get; set; }

    }
}
