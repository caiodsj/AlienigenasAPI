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
            return await _dataContext.Aliens.Where(a => a.IsInEarth == true).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Alien>> GetAllAliensDaTerra()
        {
            return await _dataContext.Aliens.Where(a => a.IsInEarth == true).ToListAsync();
        }


        public async Task<string> EntrarNaTerra(int id)
        {
            var result = await _dataContext.Aliens.Where(s => s.IsInEarth == false).FirstOrDefaultAsync(s => s.Id == id);

            if (result is not null)
            {
                result.IsInEarth = true;

                _dataContext.Aliens.Update(result);
                await _dataContext.SaveChangesAsync();

                return $"ID {id} \nData de entrada na terra: {DateTime.Now}";
            }

            return $"ID {id} esta na terra: {result.IsInEarth}\n ID não encotrado!";
        }
        public async Task<string> SairDaTerra(int id)
        {
            var result = await _dataContext.Aliens.Where(s => s.IsInEarth == true).FirstOrDefaultAsync(s => s.Id == id);

            if (result is not null)
            {
                result.IsInEarth = false;

                _dataContext.Aliens.Update(result);
                await _dataContext.SaveChangesAsync();

                return $"ID {id} \nData de saida da terra: {DateTime.Now}";
            }

            return $"ID {id} esta na terra: {result.IsInEarth}\n ID não encotrado!";
        }
    }
}
