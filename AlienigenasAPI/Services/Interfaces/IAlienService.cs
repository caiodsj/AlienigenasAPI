using AlienigenasAPI.DTOs;
using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services.Interfaces
{
    public interface IAlienService
    {
        Task<List<Alien>> GetAllAliens();
        Task<Alien?> GetAlienPorId(int id);
        Task<List<Poder>> GetAllPoderesAlien(int idAlien);
        Task<PoderAlien?> AddPoderAlien(int idAlien, int idPoder);
        Task<PoderAlien?> RemovePoderAlien(int idAlien, int idPoder);
        Task<Alien?> CreateAlien(AlienDTO request);
        Task<Alien?> UpdateAlien(int id, AlienDTO request);
        Task<Alien?> RemoveAlien(int id);
    }
}
