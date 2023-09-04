using Microsoft.AspNetCore.Mvc;
using AlienigenasAPI.DTOs;

namespace AlienigenasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetasController : ControllerBase
    {
        private readonly IPlanetaService _planetaService;

        public PlanetasController(IPlanetaService planetaService)
        {
            _planetaService = planetaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanetas()
        {
            var planetas = await _planetaService.GetAllPlanetasAsync();
            if (planetas is null || !planetas.Any())
            {
                return NotFound();
            }
            return Ok(planetas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanetaPorId(int id)
        {
            var planeta = await _planetaService.GetPlanetaPorIdAsync(id);
            if (planeta is null)
            {
                return NotFound(new { message = $"Planeta com o id-{id} não encontrado." });

            }
            return Ok(planeta);
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetPlanetaPorNome(string nome)
        {
            var planetas = await _planetaService.GetPlanetaPorNomeAsync(nome);
            if (planetas is null)
            {
                return NotFound(new { message = $"Planeta {nome} não encontrado." });
            }
            return Ok(planetas);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlanetaAsync([FromBody] PlanetaDTO request)
        {
            bool planetaExiste = await _planetaService.DoesPlanetaExistsAsync(request.Nome);
            if (planetaExiste)
            {
                return Conflict(new { message = $"O planeta {request.Nome} já existe." });
            }
            var planeta = await _planetaService.CreatePlanetaAsync(request);
            return CreatedAtAction("GetPlanetaPorId",new { id = planeta.Id },planeta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlaneta(int id,[FromBody] PlanetaUpdateDTO request)
        {
            var planeta = await _planetaService.UpdatePlanetaAsync(id,request);
            if (planeta is null)
            {
                return NotFound(new { message = $"Planeta com o id-{id} não encontrado." });
            }
            return Ok(planeta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaneta(int id)
        {
            var planetaApagado = await _planetaService.DeletePlanetaAsync(id);
            if (!planetaApagado)
            {
                return NotFound(new { message = $"Planeta com o id-{id} não encontrado." });
            }
            return NoContent();
        }
    }
}