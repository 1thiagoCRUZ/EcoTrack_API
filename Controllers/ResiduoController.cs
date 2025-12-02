using EcoTrack.DTOs;
using EcoTrack.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResiduoController : ControllerBase
    {
        private readonly RecursoService _service;

        public ResiduoController(RecursoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CreateResiduoDto dto)
        {
            var response = _service.CadastrarResiduo(dto);
            return Created($"/api/Recursos/{response.Id}", response);
        }
    }
}
