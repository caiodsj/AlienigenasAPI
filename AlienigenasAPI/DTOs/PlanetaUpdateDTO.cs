using System.ComponentModel.DataAnnotations;

namespace AlienigenasAPI.DTOs
{
    public class PlanetaUpdateDTO
    {
        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Range(0,int.MaxValue)]
        public int Populacao { get; set; }
    }
}
