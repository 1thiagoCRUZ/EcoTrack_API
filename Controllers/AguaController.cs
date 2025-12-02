using EcoTrack.DTOs;
using EcoTrack.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AguaController : ControllerBase
    {
        private readonly RecursoService _service;

        public AguaController(RecursoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CreateAguaDto dto)
        {
            try
            {
                var response = _service.CadastrarAgua(dto);
                return Created($"/api/Recursos/{response.Id}", response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
