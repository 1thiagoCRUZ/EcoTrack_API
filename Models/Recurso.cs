using System;
using System.Text.Json.Serialization; // Importante para serialização JSON

namespace EcoTrack.Models
{
    public abstract class Recurso
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // Inicializado para evitar null
        public string Localizacao { get; set; } = string.Empty; // Inicializado para evitar null

        public double MetaConsumoMensal { get; set; } // Vai servir pra gente limitar e conseguir gerar o alerta
        public string UnidadeMedida { get; set; } = string.Empty; 

        public StatusOperacional Status { get; set; } = StatusOperacional.Ativo; // Valor padrão

        [JsonIgnore]
        public List<Leitura> Leituras { get; set; } = new();
    }
}
