using System;
using EcoTrack.Models;
using System.ComponentModel.DataAnnotations;

namespace EcoTrack.DTOs
{
    public class CreateEnergiaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;
        
        public string Localizacao { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "A meta deve ser positiva")]
        public double MetaConsumoMensal { get; set; }

        public string UnidadeMedida { get; set; } = string.Empty;

        [Required]
        public int Voltagem { get; set; }

        public TipoFonteEnergia Fonte { get; set; }

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