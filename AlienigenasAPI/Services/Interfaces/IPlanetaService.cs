using AlienigenasAPI.DTOs;
using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services.Interfaces
{
    public interface IPlanetaService
    {
        Task<List<Planeta>> GetAllPlanetas();
        Task<Planeta> GetPlanetaPorId(int id);
        Task<Planeta> CreatePlaneta(PlanetaDTO request);
        Task<Planeta> UpdatePlaneta(int id, PlanetaDTO request);
        Task RemovePlaneta(int id);
    }
}
