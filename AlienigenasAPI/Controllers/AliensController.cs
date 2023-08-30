using AlienigenasAPI.DTOs;
using AlienigenasAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlienigenasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliensController : ControllerBase
    {
        private readonly IAlienService _alienService;

        public AliensController(IAlienService alienService)
        {
            _alienService = alienService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alien>>> GetAllAlienes()
        {
            return Ok(await _alienService.GetAllAliens());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alien>> GetAlienById(int id)
        {
            var alien = await _alienService.GetAlienPorId(id);
            if (alien == null) return NotFound("Nenhum alien encontrado");
            return Ok(alien);
        }

        [HttpGet("{id}/poderes")]
        public async Task<ActionResult<IEnumerable<Poder>>> GetAllPoderesAlien(int id)
        {
            var poderes = await _alienService.GetAllPoderesAlien(id);
            if (poderes == null) return NotFound($"Nenhum poder encontrado para o alien {id}");
            return Ok(poderes);
        }

        [HttpPost("{id}/poderes/{idPoder}")]
        public async Task<ActionResult> AddPoderAlien(int id, int idPoder)
        {
            var poderAlien = await _alienService.AddPoderAlien(id, idPoder);
            if (poderAlien == null) BadRequest();
            return Ok(poderAlien);
        }

        [HttpDelete("{id}/poderes/{idPoder}")]
        public async Task<ActionResult> RemovePoderAlien(int id, int idPoder)
        {
            var poderAlien = await _alienService.RemovePoderAlien(id, idPoder);
            if (poderAlien == null) NotFound();
            return Ok($"Poder {idPoder} do alien {id} removido com sucesso.");
        }

        [HttpPost]
        public async Task<ActionResult> CreateAlien(AlienDTO request)
        {
            var alien = await _alienService.CreateAlien(request);
            if (alien == null) BadRequest();
            return Ok(alien);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAlien(int id, AlienDTO request)
        {
            var alien = await _alienService.UpdateAlien(id, request);
            if (alien == null) NotFound();
            return Ok($"O alien {request.Nome} foi atualizado");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlien(int id)
        {
            var alien = await _alienService.RemoveAlien(id);
            if (alien == null) NotFound();
            return Ok($"Alien {id} excluído com sucesso.");
        }
    }
}
