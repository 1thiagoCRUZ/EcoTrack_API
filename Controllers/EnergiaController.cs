using EcoTrack.DTOs;
using EcoTrack.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergiaController : ControllerBase
    {
        private readonly RecursoService _service;

        public EnergiaController(RecursoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CreateEnergiaDto dto)
        {
            try
            {
                var response = _service.CadastrarEnergia(dto);
                return CreatedAtAction(nameof(Cadastrar), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}