using System.ComponentModel.DataAnnotations;
using EcoTrack.Models;

namespace EcoTrack.DTOs
{
    public class CreateAguaDto
    {
        [Required] public string Nome { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public double MetaConsumoMensal { get; set; }
        public double Pressao { get; set; }
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