using System;

namespace EcoTrack.Models
{
    public enum TipoFonteEnergia
    {
        RedeEletrica = 1,
        Solar = 2,
        Eolica = 3,
        GeradorDiesel = 4
    }

    public enum StatusOperacional
    {
        Ativo = 1,
        Manutencao = 2,
        Inativo = 3,
        ErroSensor = 4 // Caso de pau no sensor
    }

    public enum TipoUsoAgua
    {
        Potavel = 1,
        Reuso = 2,
        Irrigacao = 3,
        Industrial = 4
    }

}
