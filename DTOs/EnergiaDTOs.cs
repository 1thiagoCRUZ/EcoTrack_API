using System.ComponentModel.DataAnnotations;
using EcoTrack.Models;

namespace EcoTrack.DTOs
{
    public class CreateEnergiaDto
    {
        [Required(ErrorMessage = "O nome do equipamento é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A localização é obrigatória.")]
        public string Localizacao { get; set; } = string.Empty;

        [Range(0.1, double.MaxValue, ErrorMessage = "A meta deve ser maior que zero.")]
        public double MetaConsumoMensal { get; set; }

        // Opcional, mas se mandar, validamos o tamanho
        [StringLength(10, ErrorMessage = "A unidade deve ser curta (ex: kWh).")]
        public string UnidadeMedida { get; set; } = "kWh";

        [Range(1, 1000, ErrorMessage = "A voltagem deve ser válida (ex: 110, 220, 380).")]
        public int Voltagem { get; set; }

        [Required(ErrorMessage = "A fonte de energia é obrigatória.")]
        public TipoFonteEnergia Fonte { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O fator de emissão não pode ser negativo.")]
        public double FatorEmissaoCO2 { get; set; }
    }

    public class ResponseEnergiaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public double MetaConsumoMensal { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;
        public int Voltagem { get; set; }
        public string FonteDescricao { get; set; } = string.Empty;
        public double PegadaCarbono { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}