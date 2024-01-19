using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APISuperHeroi.Model
{
    public class Heroi
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public  string? Nome { get; set; }
        [Required]
        public  string? NomeHeroi { get; set; }
        public DateTime? DataNascimento { get; set; }
        public double? Altura { get; set; }
        public double? Peso { get; set; }
        public ICollection<HeroisSuperPoderes> HeroisSuperPoderes { get; set; } 
    }
}
