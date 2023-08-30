using AlienigenasAPI.Models;

namespace AlienigenasAPI.DTOs
{
    public class AlienDTO
    {
        public string Nome { get; set; }
        public string Especie { get; set; }
        public int Altura { get; set; }
        public int Idade { get; set; }
        public string CorpoDescricao { get; set; }
        public int PlanetaOrigemId { get; set; }
        public Planeta PlanetaOrigem { get; set; }
        public List<PoderAlien> PoderesAliens { get; set; }
        public bool IsInEarth { get; set; }
    }
}
