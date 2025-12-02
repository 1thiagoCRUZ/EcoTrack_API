using System.ComponentModel.DataAnnotations;

namespace EcoTrack.DTOs
{
    public class CreateResiduoDto
    {
        [Required(ErrorMessage = "O nome do ponto de coleta é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A localização é obrigatória.")]
        public string Localizacao { get; set; } = string.Empty;

        [Range(0.1, double.MaxValue, ErrorMessage = "A meta de geração deve ser maior que zero.")]
        public double MetaConsumoMensal { get; set; } 

        [Required(ErrorMessage = "O tipo de material é obrigatório (ex: Plástico, Vidro).")]
        public string TipoMaterial { get; set; } = string.Empty;
        public bool Reciclavel { get; set; }
    }

    public class ResponseResiduoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string TipoMaterial { get; set; } = string.Empty;
        public bool IsReciclavel { get; set; }
        public double MetaGeracao { get; set; }
    }
}