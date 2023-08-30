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

        [HttpGet("BuscarTodosAliensQueEstaoNaTerra")]
        public async Task<ActionResult<List<Alien>>> GetAllAliensDaTerra()
        {
            var aliens = await _terraService.GetAllAliensDaTerra();

            if (aliens is null) { return BadRequest("Nenhum Alien esta na terra!"); }

            return Ok(aliens);
        }

        [HttpGet("BuscarAlienNaTerraPorId/{id}")]
        public async Task<ActionResult<Alien>> GetAlienNaTerraPorId(int id)
        {
            var alien = await _terraService.GetAlienNaTerraPorId(id);

            if (alien is null) { return BadRequest("Esse alien não esta na terra!"); }

            return Ok(alien);
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
