using System;

namespace EcoTrack.Models
{
    public class  Residuo : Recurso
    {
        public string TipoMaterial { get; set; } = string.Empty;
        public bool Reciclavel { get; set; } = false;
    }
}