using AlienigenasAPI.DTOs;
using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services.Interfaces
{
    public interface IPlanetaService
    {
        // create
        Task<Planeta> CreatePlanetaAsync(PlanetaDTO request);

        // read
        Task<List<Planeta>> GetAllPlanetasAsync();
        Task<Planeta> GetPlanetaPorIdAsync(int id);

        // update
        Task<Planeta> UpdatePlanetaAsync(int id,PlanetaDTO request);

        // delete
        Task<bool> DeletePlanetaAsync(int id);
    }
}
