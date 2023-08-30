using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services
{
    public class TerraService : ITerraService
    {
        private readonly DataContext _dataContext;

        public TerraService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Alien> GetAlienNaTerraPorId(int id)
        {
            return await _dataContext.Aliens.Where(a => a.EstaNaTerra == true).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Alien>> GetAlienNaTerraPorNome(string nomeAlien)
        {
            return await _dataContext.Aliens.Where(a => a.EstaNaTerra == true && a.Nome.Contains(nomeAlien)).ToListAsync();
        }

        public async Task<List<Alien>> GetAlienNaTerraPorEspecie(string especie)
        {
            return await _dataContext.Aliens.Where(a => a.EstaNaTerra == true && a.Especie.Contains(especie)).ToListAsync();
        }

        public async Task<List<Alien>> GetAllAliensDaTerra()
        {
            return await _dataContext.Aliens.Where(a => a.EstaNaTerra == true).ToListAsync();
        }

        public async Task<List<Alien>> GetAllAliensPorPlaneta(int idPlaneta)
        {
            return await _dataContext.Aliens.Where(a => a.EstaNaTerra == true && a.PlanetaOrigemId == idPlaneta).ToListAsync();
        }


        public async Task<string> EntrarNaTerra(int id)
        {
            var result = await _dataContext.Aliens.FirstOrDefaultAsync(s => s.Id == id);

            if (result is null) return "Alien não existe.";
            if (result.EstaNaTerra) return "Alien já está na terra!";
            result.EstaNaTerra = true;

            _dataContext.Aliens.Update(result);
            await _dataContext.SaveChangesAsync();

            return $"ID {id} \nData de entrada na terra: {DateTime.Now}";


        }
        public async Task<string> SairDaTerra(int id)
        {
            var result = await _dataContext.Aliens.FirstOrDefaultAsync(s => s.Id == id);

            if (result is null) return "Alien não existe.";
            if (!result.EstaNaTerra) return "Alien não está na terra!";
            result.EstaNaTerra = false;

            _dataContext.Aliens.Update(result);
            await _dataContext.SaveChangesAsync();

            return $"ID {id} \nData de saída da terra: {DateTime.Now}";
        }
    }
}
