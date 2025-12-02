using System;

namespace EcoTrack.Models
{
    public class Agua : Recurso 
    {
        public double Pressao { get; set; }
        public TipoUsoAgua TipoUso { get; set; }
    }
}