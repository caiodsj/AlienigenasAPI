using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services.Interfaces
{
    public interface ITerraService
    {
        Task<List<Alien>> GetAllAliensDaTerra();
        Task<Alien> GetAlienNaTerraPorId(int id);
        Task EntrarNaTerra(int id);
        Task SairDaTerra(int id);
    }
}
