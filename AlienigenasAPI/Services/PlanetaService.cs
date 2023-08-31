using AlienigenasAPI.Models;
using AlienigenasAPI.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Globalization;

namespace AlienigenasAPI.Services
{
    public class PlanetaService : IPlanetaService
    {
        private readonly DataContext _dataContext;

        public PlanetaService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<List<Planeta>> GetAllPlanetasAsync()
        {
            return await _dataContext.Planetas.ToListAsync();
        }

        public async Task<Planeta> GetPlanetaPorIdAsync(int id)
        {
            return await _dataContext.Planetas.FindAsync(id);
        }

        public async Task<List<Planeta>> GetAllPlanetasPorNomeAsync(string nome)
        {
            var planetas = await _dataContext.Planetas
                .Where(p => p.Nome.Contains(nome))
                .ToListAsync();
            return planetas;
        }

        public async Task<bool> DoesPlanetaExistsAsync(string nome)
        {
            var planetaExistente = await _dataContext.Planetas
                .Where(p => p.Nome == nome)
                .FirstOrDefaultAsync();
            return planetaExistente != null;
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

        public async Task<Planeta> UpdatePlanetaAsync(int id,PlanetaUpdateDTO request)
        {
            var planeta = await _dataContext.Planetas.FindAsync(id);
            if (planeta == null)
            {
                return null;
            }
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