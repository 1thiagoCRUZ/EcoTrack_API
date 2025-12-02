using System.ComponentModel.DataAnnotations;

namespace EcoTrack.DTOs
{
    public class CreateLeituraDto
    {
        [Required(ErrorMessage = "O ID do recurso é obrigatório.")]
        public int RecursoId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "A leitura deve ser positiva e maior que zero.")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O ID do sensor físico é obrigatório.")]
        public string SensorId { get; set; } = "SENSOR-GENERICO";
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