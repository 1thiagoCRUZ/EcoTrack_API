using EcoTrack.DTOs;
using EcoTrack.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecursosController : ControllerBase
    {
        private readonly RecursoService _service;

        public RecursosController(RecursoService service)
        {
            _service = service;
        }

        [HttpPost("leitura")]
        public IActionResult ReceberDados([FromBody] CreateLeituraDto dto)
        {
            try
            {
                var leitura = _service.ProcessarLeitura(dto);
                
                if (leitura.HouveAlerta)
                {
                    return Ok(new
                    {
                        status = "ALERTA",
                        mensagem = "Consumo crítico detectado! Verifique o equipamento.",
                        dados = leitura
                    });
                }

                return Ok(new { status = "OK", dados = leitura });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet("dashboard")]
        public IActionResult GetDashboard()
        {
            var stats = _service.GerarDashboard();
            return Ok(stats);
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_service.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var recurso = _service.ObterPorId(id);
            if (recurso == null) return NotFound(new { mensagem = "Recurso não encontrado" });
            
            return Ok(recurso);
        }

        [HttpPatch("meta")]
        public IActionResult AtualizarMeta([FromBody] UpdateMetaDto dto)
        {
            try
            {
                _service.AtualizarMeta(dto);
                return Ok(new { mensagem = "Meta atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _service.RemoverRecurso(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { erro = ex.Message });
            }
        }
    }
}
