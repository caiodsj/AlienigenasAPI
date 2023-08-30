using Microsoft.AspNetCore.Mvc;
using AlienigenasAPI.DTOs;

[Route("api/[controller]")]
[ApiController]
public class PlanetasController : ControllerBase
{
    private readonly IPlanetaService _planetaService;

    public PlanetasController(IPlanetaService planetaService)
    {
        _planetaService = planetaService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlanetaAsync([FromBody] PlanetaDTO request)
    {
        var planeta = await _planetaService.CreatePlanetaAsync(request);
        return CreatedAtAction("GetPlanetaPorId",new { id = planeta.Id },planeta);
    }

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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlaneta(int id)
    {
        var planetaApagado = await _planetaService.DeletePlanetaAsync(id);
        if (!planetaApagado)
        {
            return NotFound("Planeta não encontrado.");
        }
        return NoContent();
    }
}
