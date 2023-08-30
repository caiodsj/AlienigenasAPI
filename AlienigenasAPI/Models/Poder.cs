namespace AlienigenasAPI.Models
{
    public class Poder
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<PoderAlien> PoderesAlien { get; set; }
    }
}
