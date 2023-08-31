namespace AlienigenasAPI.Models
{
    public class PoderAlien
    {
        public int AlienId { get; set; }
        public int PoderId { get; set; }

        public Alien Alien { get; set; }
        public Poder Poder { get; set; }
    }
}
