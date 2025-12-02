using System;

namespace EcoTrack.Models
{
    public class  Leitura
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataLeitura { get; set; } = DateTime.Now; // pega a data/hora atual

        public string SensorId { get; set; } = Guid.NewGuid().ToString().Substring(0,8);

        public bool AlertaGerado { get; set; } = false; // Indica se um alerta foi gerado para esta leitura

        public int RecursoId { get; set; }
        public Recurso? Recurso { get; set; }
    }
}
