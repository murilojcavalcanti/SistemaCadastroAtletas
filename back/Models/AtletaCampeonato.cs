using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class AtletaCampeonato
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string? AtletaId { get; set; }
        public virtual Atletas Atleta { get; set; }

        public int? CampeonatoId { get; set; }
        public virtual Campeonatos Campeonatos { get; set; }



    }
}
