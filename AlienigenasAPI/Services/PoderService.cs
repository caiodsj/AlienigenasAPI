using AlienigenasAPI.DTOs;
using AlienigenasAPI.Models;

namespace AlienigenasAPI.Services
{
    public class PoderService : IPoderService
    {
        private readonly DataContext _dataContext;

        public PoderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Poder>> GetAllPoderes()
        {
            return await _dataContext.Poderes.ToListAsync();
        }

        public async Task<Poder> GetPoderPorId(int id)
        {
            return await _dataContext.Poderes.FindAsync(id);
        }
        public async Task<string> CreatePoder(PoderDTO request)
        {
            var poder = new Poder
            {
                Nome = request.Nome,
                Descricao = request.Descricao
            };
            await _dataContext.Poderes.AddAsync(poder);
            await _dataContext.SaveChangesAsync();
            return $"O poder '{poder.Nome}' foi criado com sucesso.";
        }

        public async Task<string> UpdatePoder(int id, PoderDTO request)
        {
            var poder = await _dataContext.Poderes.FindAsync(id);
            if (poder == null) return null;
            poder.Nome = request.Nome;
            poder.Descricao = request.Descricao;
            await _dataContext.SaveChangesAsync();
            return $"'{poder.Nome}' foi atualizado com sucesso.";
        }
        public async Task<string> RemovePoder(int id)
        {
            var poder = await _dataContext.Poderes.FindAsync(id);
            if (poder == null) return null;
            _dataContext.Poderes.Remove(poder);
            await _dataContext.SaveChangesAsync();
            return $"O poder '{poder.Nome}' foi excluído com sucesso.";
        }
    }
}
