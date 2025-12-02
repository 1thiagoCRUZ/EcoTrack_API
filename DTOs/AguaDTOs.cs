using System.ComponentModel.DataAnnotations;
using EcoTrack.Models;

namespace EcoTrack.DTOs
{
    public class CreateAguaDto
    {
        [Required(ErrorMessage = "O nome do ponto de água é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A localização é obrigatória.")]
        public string Localizacao { get; set; } = string.Empty;

        [Range(0.1, double.MaxValue, ErrorMessage = "A meta de consumo deve ser maior que zero.")]
        public double MetaConsumoMensal { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "A pressão deve ser maior que zero.")]
        public double Pressao { get; set; }

        [Required(ErrorMessage = "O tipo de uso da água é obrigatório.")]
        public TipoUsoAgua TipoUso { get; set; }
    }

    public class ResponseAguaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public double Meta { get; set; }
        public double Pressao { get; set; }
        public string TipoUsoDescricao { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}