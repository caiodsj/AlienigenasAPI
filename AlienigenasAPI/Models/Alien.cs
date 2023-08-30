namespace AlienigenasAPI.Models
{
    public class Alien
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public int Altura { get; set; }
        public int Idade { get; set; }
        public string CorpoDescricao { get; set; }
        public bool EstaNaTerra { get; set; }

        public int PlanetaOrigemId { get; set; }
        public Planeta PlanetaOrigem { get; set; }
        public List<PoderAlien> PoderesAlien { get; set; }
    }
}
