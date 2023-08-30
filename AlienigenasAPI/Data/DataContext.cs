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
                .HasForeignKey(a => a.PlanetaOrigemId)
                .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<PoderAlien>()
				.HasKey(pa => new { pa.AlienId, pa.PoderId });
            modelBuilder.Entity<Alien>()
                .HasMany(a => a.PoderesAlien).WithOne(pa => pa.Alien)
                .HasForeignKey(pa => pa.AlienId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Poder>()
                .HasMany(p => p.PoderesAlien).WithOne(pa => pa.Poder)
                .HasForeignKey(pa => pa.PoderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
