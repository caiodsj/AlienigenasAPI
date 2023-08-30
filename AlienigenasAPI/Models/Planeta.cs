namespace AlienigenasAPI.Models
{
    public class Planeta
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Populacao { get; set; } = 0;
    }
}
