using AlienigenasAPI.DTOs;
using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services.Interfaces
{
    public interface IPoderService
    {
        Task<List<Poder>> GetAllPoderes();
        Task<Poder> GetPoderPorId(int id);
        Task<Poder> CreatePoder(PoderDTO request);
        Task<Poder> UpdatePoder(int id, PoderDTO request);
        Task RemovePoder(int id);
    }
}
