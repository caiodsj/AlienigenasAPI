using Microsoft.EntityFrameworkCore;
using AlienigenasAPI.Models;
using AlienigenasAPI.Services.Interfaces;
using AlienigenasAPI.DTOs;

public class PlanetaService : IPlanetaService
{
    private readonly DataContext _dataContext;

    public PlanetaService(DataContext context)
    {
        _dataContext = context;
    }

    public async Task<List<Planeta>> GetAllPlanetas()
    {
        return await _dataContext.Planetas.ToListAsync();
    }

    public async Task<Planeta> GetPlanetaPorId(int id)
    {
        return await _dataContext.Planetas.FindAsync(id);
    }

    public async Task<Planeta> CreatePlaneta(PlanetaDTO request)
    {
        var planeta = new Planeta
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            Populacao = request.Populacao
        };
        _dataContext.Planetas.Add(planeta);
        await _dataContext.SaveChangesAsync();
        return planeta;
    }

    public async Task<Planeta> UpdatePlaneta(int id,PlanetaDTO request)
    {
        var planeta = await _dataContext.Planetas.FindAsync(id);
        if (planeta == null)
        {
            return null;
        }
        planeta.Nome = request.Nome;
        planeta.Descricao = request.Descricao;
        planeta.Populacao = request.Populacao;
        await _dataContext.SaveChangesAsync();
        return planeta;
    }

    public async Task RemovePlaneta(int id)
    {
        var planeta = await _dataContext.Planetas.FindAsync(id);
        if (planeta != null)
        {
            _dataContext.Planetas.Remove(planeta);
            await _dataContext.SaveChangesAsync();
        }
    }
}
