using System.ComponentModel.DataAnnotations;

namespace EcoTrack.DTOs
{
    public class CreateResiduoDto
    {
        [Required] public string Nome { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public double MetaConsumoMensal { get; set; }
        [Required] public string TipoMaterial { get; set; } = string.Empty;
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