using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APISuperHeroi.Model
{
    public class HeroisSuperPoderes
    {
        [Key]
       
        public int HeroiId { get; set; }
        public Heroi? Heroi { get; set; }       
        public int SuperPoderesId { get; set; }
        public SuperPoderes? SuperPoderes { get; set; }

    }
}
