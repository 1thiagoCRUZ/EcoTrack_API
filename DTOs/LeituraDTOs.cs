using System.ComponentModel.DataAnnotations;
using EcoTrack.Models;

namespace EcoTrack.DTOs
{
    public class CreateLeituraDto
    {
        [Required]
        public int RecursoId { get; set; }
        
        [Range(0.01, double.MaxValue, ErrorMessage= "A leitura deve ser maior que zero")]
        public double Valor { get; set; }

        public string SensorId { get; set; } = "SENSOR-GENÉRICO";
    }
    public class ResponseLeituraDto
    {
        public int Id { get; set; }
        public int RecursoId { get; set; }
        public double Valor { get; set; }
        public DateTime DataLeitura { get; set; }
        public string SensorId { get; set; } = string.Empty;

        public bool HouveAlerta { get; set; }
        public string MensagemAlerta { get; set; } = string.Empty;
    }
}