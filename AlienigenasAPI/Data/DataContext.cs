using AlienigenasAPI.Models;

namespace AlienigenasAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Planeta> Planetas { get; set; }
        public DbSet<Alien> Aliens { get; set; }
        public DbSet<Poder> Poderes { get; set; }
        public DbSet<PoderAlien> PoderesAliens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alien>()
                .HasOne(a => a.PlanetaOrigem).WithMany()
                .HasForeignKey(a => a.PlanetaOrigemId);

            modelBuilder.Entity<PoderAlien>()
                .HasOne(pa => pa.Alien).WithMany()
                .HasForeignKey(pa => pa.AlienId);

            modelBuilder.Entity<PoderAlien>()
                .HasOne(pa => pa.Poder).WithMany()
                .HasForeignKey(pa => pa.PoderId);
        }
    }
}
