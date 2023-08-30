using AlienigenasAPI.Models;
using AlienigenasAPI.DTOs;

namespace AlienigenasAPI.Services
{
    public class PlanetaService : IPlanetaService
    {
        private readonly DataContext _dataContext;

        public PlanetaService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<Planeta> CreatePlanetaAsync(PlanetaDTO request)
        {
            var planeta = new Planeta
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Populacao = request.Populacao
            };
            _dataContext.Planetas.Add(planeta);
            await _dataContext.SaveChangesAsync();
            return planeta;
        }

        public async Task<List<Planeta>> GetAllPlanetasAsync()
        {
            return await _dataContext.Planetas.ToListAsync();
        }

        public async Task<Planeta> GetPlanetaPorIdAsync(int id)
        {
            return await _dataContext.Planetas.FindAsync(id);
        }

        public async Task<Planeta> UpdatePlanetaAsync(int id,PlanetaDTO request)
        {
            var planeta = await _dataContext.Planetas.FindAsync(id);
            if (planeta == null)
            {
                return null;
            }
            planeta.Nome = request.Nome;
            planeta.Descricao = request.Descricao;
            planeta.Populacao = request.Populacao;
            await _dataContext.SaveChangesAsync();
            return planeta;
        }

        public async Task<bool> DeletePlanetaAsync(int id)
        {
            var planeta = await _dataContext.Planetas.FindAsync(id);
            if (planeta == null)
            {
                return false;
            }
            _dataContext.Planetas.Remove(planeta);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}