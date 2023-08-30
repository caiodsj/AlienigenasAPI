using Microsoft.AspNetCore.Mvc;
using AlienigenasAPI.DTOs;
using AlienigenasAPI.Services.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class PlanetasController : ControllerBase
{
    private readonly IPlanetaService _planetaService;

    public PlanetasController(IPlanetaService planetaService)
    {
        _planetaService = planetaService;
    }

    // POST: api/Planetas
    [HttpPost]
    public async Task<IActionResult> CreatePlanetaAsync([FromBody] PlanetaDTO request)
    {
        var planeta = await _planetaService.CreatePlanetaAsync(request);
        return CreatedAtAction("GetPlanetaPorId",new { id = planeta.Id },planeta);
    }

    // GET: api/Planetas
    [HttpGet]
    public async Task<IActionResult> GetAllPlanetas()
    {
        var planetas = await _planetaService.GetAllPlanetasAsync();
        if (planetas == null || !planetas.Any())
        {
            return NotFound();
        }
        return Ok(planetas);
    }

    // GET: api/Planetas/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlanetaPorId(int id)
    {
        var planeta = await _planetaService.GetPlanetaPorIdAsync(id);
        if (planeta == null)
        {
            return NotFound();
        }
        return Ok(planeta);
    }

    // PUT: api/Planetas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlaneta(int id,[FromBody] PlanetaDTO request)
    {
        var planeta = await _planetaService.UpdatePlanetaAsync(id,request);
        if (planeta == null)
        {
            return NotFound();
        }
        return Ok(planeta);
    }

    // DELETE: api/Planetas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePlaneta(int id)
    {
        await _planetaService.RemovePlanetaAsync(id);
        return NoContent();
    }
}
