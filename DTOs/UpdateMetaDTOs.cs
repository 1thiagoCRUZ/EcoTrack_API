using System.ComponentModel.DataAnnotations;
using EcoTrack.Models;

namespace EcoTrack.DTOs
{
    public class UpdateMetaDto
    {
        [Required]
        public int RecursoId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "A meta deve ser positiva")]
        public double NovaMeta { get; set; }
    }

    public class ResponseMensagemDto
    {
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; }
    }
}