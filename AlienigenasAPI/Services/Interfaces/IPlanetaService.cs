using AlienigenasAPI.DTOs;
using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services.Interfaces
{
    public interface IPlanetaService
    {
        Task<List<Planeta>> GetAllPlanetasAsync();
        Task<Planeta> GetPlanetaPorIdAsync(int id);
        Task<Planeta> GetPlanetaPorNomeAsync(string nome);
        Task<Planeta> CreatePlanetaAsync(PlanetaDTO request);
        Task<bool> DoesPlanetaExistsAsync(string nome);
        Task<Planeta> UpdatePlanetaAsync(int id,PlanetaUpdateDTO request);
        Task<bool> DeletePlanetaAsync(int id);
    }
}
