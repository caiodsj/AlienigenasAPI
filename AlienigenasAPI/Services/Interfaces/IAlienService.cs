using AlienigenasAPI.DTOs;
using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services.Interfaces
{
    public interface IAlienService
    {
        Task<List<Alien>> GetAllAliens();
        Task<Alien> GetAlienPorId(int id);
        Task<Alien> CreateAlien(AlienDTO request);
        Task<Alien> UpdateAlien(int id, AlienDTO request);
        Task RemoveAlien(int id);
    }
}
