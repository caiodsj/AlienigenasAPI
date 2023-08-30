using AlienigenasAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlienigenasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerraController : ControllerBase
    {
        private readonly ITerraService _terraService;

        public TerraController(ITerraService terraService)
        {
            _terraService = terraService;
        }

        [HttpGet("BuscarAliens")]
        public async Task<ActionResult<List<Alien>>> GetAllAliens()
        {
            var aliens = await _terraService.GetAllAliensDaTerra();

            if (aliens is null) { return BadRequest("Nenhum Alien esta na terra!"); }

            return Ok(aliens);
        }

        [HttpGet("BuscarAlienPorId/{id}")]
        public async Task<ActionResult<Alien>> GetAlienPorId(int id)
        {
            var alien = await _terraService.GetAlienNaTerraPorId(id);

            if (alien is null) { return BadRequest("Esse alien não esta na terra!"); }

            return Ok(alien);
        }

        [HttpGet("BuscarAliensPorPlanetaId/{id}")]
        public async Task<ActionResult<List<Alien>>> GetAlienNaTerraPorId(int id)
        {
            var aliens = await _terraService.GetAllAliensPorPlaneta(id);

            if (aliens is null) { return BadRequest($"Não existe nenhum visitante desse planeta na Terra"); }

            return Ok(aliens);
        }

        [HttpPut("EntradaNaTerra/{id}")]
        public async Task<ActionResult<string>> EntrarNaTerra(int id)
        {
            var result = await _terraService.EntrarNaTerra(id);

            return Ok(result);
        }

        [HttpPut("SaidaDaTerra/{id}")]
        public async Task<ActionResult<string>> SairDaTerra(int id)
        {
            var result = await _terraService.EntrarNaTerra(id);

            return Ok(result);
        }
    }
}
