using AlienigenasAPI.DTOs;
using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services.Interfaces
{
    public interface IPoderService
    {
        Task<List<Poder>> GetAllPoderes();
        Task<Poder> GetPoderPorId(int id);
        Task<string> CreatePoder(PoderDTO request);
        Task<string> UpdatePoder(int id, PoderDTO request);
        Task<string> RemovePoder(int id);
    }
}
