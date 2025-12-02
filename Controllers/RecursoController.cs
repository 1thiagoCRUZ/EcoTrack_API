using EcoTrack.DTOs;
using EcoTrack.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoramentoController : ControllerBase
    {
        private readonly RecursoService _service;

        public MonitoramentoController(RecursoService service)
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
    }
}