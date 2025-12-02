using System;

namespace EcoTrack.Models
{
    public class Energia : Recurso // Herdando de Recurso
    {
        public int Voltagem { get; set; }
        public TipoFonteEnergia Fonte { get; set; }

        public double FatorEmissaoCO2 { get; set; }
    }
}
