using AlienigenasAPI.Models;
using AlienigenasAPI.DTOs;

namespace AlienigenasAPI.Services
{
    public class AlienService : IAlienService
    {
        private readonly DataContext _dataContext;

        public AlienService(DataContext dbContext) { _dataContext = dbContext; }

        public async Task<List<Alien>> GetAllAliens()
        {
            return await _dataContext.Aliens
                .Include(a => a.PlanetaOrigem).Include(a => a.PoderesAlien)
                .ToListAsync();
        }

        public async Task<Alien?> GetAlienPorId(int id)
        {
            return await _dataContext.Aliens
                .Include(a => a.PlanetaOrigem).Include(a => a.PoderesAlien)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Poder>> GetAllPoderesAlien(int idAlien)
        {
            return await _dataContext.PoderesAliens
                .Where(pa => pa.AlienId == idAlien)
                .Include(pa => pa.Poder)
                .Select(pa => pa.Poder)
                .ToListAsync();
        }

        public async Task<PoderAlien?> AddPoderAlien(int idAlien, int idPoder)
        {
            var poderAlien = await _dataContext.PoderesAliens.FindAsync(idAlien, idPoder);
            if (poderAlien is not null) return null;

            poderAlien = new PoderAlien{ AlienId = idAlien, PoderId = idPoder };

            await _dataContext.PoderesAliens.AddAsync(poderAlien);
            await _dataContext.SaveChangesAsync();
            return poderAlien;
        }

        public async Task<PoderAlien?> RemovePoderAlien(int idAlien, int idPoder)
        {
            var poderAlien = await _dataContext.PoderesAliens.FindAsync(idAlien, idPoder);
            if (poderAlien is null) return null;

            _dataContext.PoderesAliens.Remove(poderAlien);
            await _dataContext.SaveChangesAsync();
            return poderAlien;
        }

        public async Task<Alien?> CreateAlien(AlienDTO request)
        {
            Alien alien = new Alien{
                Nome = request.Nome,
                Especie = request.Especie,
                Altura = request.Altura,
                Idade = request.Idade,
                CorpoDescricao = request.CorpoDescricao,
                EstaNaTerra = false,
                PlanetaOrigemId = request.PlanetaOrigemId,
            };
            var poderesAlien = request.Poderes
                .Select(id => new PoderAlien{ AlienId = alien.Id, PoderId = id })
                .ToList();
            alien.PoderesAlien = poderesAlien;

            await _dataContext.Aliens.AddAsync(alien);
            await _dataContext.SaveChangesAsync();
            return alien;
        }

        public async Task<Alien?> UpdateAlien(int id, AlienDTO request)
        {
            var alien = await _dataContext.Aliens.FindAsync(id);
            if (alien is null) return null;

            alien.Nome = request.Nome;
            alien.Especie = request.Especie;
            alien.Altura = request.Altura;
            alien.Idade = request.Idade;
            alien.CorpoDescricao = request.CorpoDescricao;
            alien.PlanetaOrigemId = request.PlanetaOrigemId;

            var poderesAlien = alien.PoderesAlien.ToList();

            poderesAlien.RemoveAll(pa => !request.Poderes.Contains(pa.PoderId));
            poderesAlien.AddRange(request.Poderes.Select(id => new PoderAlien{ AlienId = alien.Id, PoderId = id }));

            alien.PoderesAlien = poderesAlien;

            await _dataContext.SaveChangesAsync();
            return alien;
        }

        public async Task<Alien?> RemoveAlien(int id)
        {
            var alien = await _dataContext.Aliens.FindAsync(id);
            if (alien is null) return null;

            _dataContext.Aliens.Remove(alien);
            await _dataContext.SaveChangesAsync();
            return alien;
        }
    }
}