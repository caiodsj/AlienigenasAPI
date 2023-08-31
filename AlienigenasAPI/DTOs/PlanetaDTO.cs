using System.ComponentModel.DataAnnotations;

namespace AlienigenasAPI.DTOs
{
    public class PlanetaDTO
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Range(0,int.MaxValue)]
        public int Populacao { get; set; }
    }
}
