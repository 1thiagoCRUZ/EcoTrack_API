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
            var response = _service.CadastrarAgua(dto);
            return CreatedAtAction(nameof(Cadastrar), new { id = response.Id }, response);
        }
    }
}