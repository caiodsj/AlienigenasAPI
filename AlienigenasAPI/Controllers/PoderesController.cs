using AlienigenasAPI.DTOs;
using AlienigenasAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlienigenasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoderesController : ControllerBase
    {
        private readonly IPoderService _poderService;

        public PoderesController(IPoderService poderService)
        {
            _poderService = poderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poder>>> GetAllPoderes()
        {
            return Ok(await _poderService.GetAllPoderes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Poder>> GetPoderById(int id)
        {
            var poder = await _poderService.GetPoderPorId(id);
            if (poder == null) return NotFound("Nenhum poder encontrado");
            return Ok(poder);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePoder(PoderDTO poder)
        {
            await _poderService.CreatePoder(poder);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePoder(int id, PoderDTO request)
        {
            await _poderService.UpdatePoder(id, request);
            return Ok($"O poder {request.Nome} foi atualizado");
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePoder(int id)
        {
            await _poderService.RemovePoder(id);
            return Ok("Poder excluído com sucesso.");
        }
        
    }
}
