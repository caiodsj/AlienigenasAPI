using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services.Interfaces
{
    public interface ITerraService
    {
        Task<List<Alien>> GetAllAliensDaTerra();
        Task<List<Alien>> GetAllAliensPorPlaneta(int idPlaneta);
        Task<Alien> GetAlienNaTerraPorId(int id);
        Task<string> EntrarNaTerra(int id);
        Task<string> SairDaTerra(int id);
    }
}
