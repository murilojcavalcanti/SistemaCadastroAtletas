namespace back.Models
{
    public class AtletasLutas
    {
        public string AtletasId { get; set; }
        public virtual Atletas Atletas { get; set; }

        public int LutasId { get; set; }
        public virtual Lutas Lutas { get; set; }
    }
}
