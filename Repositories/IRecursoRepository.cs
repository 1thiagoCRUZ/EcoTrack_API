using System;
using EcoTrack.Models;

namespace EcoTrack.Repositories
{
    public interface IRecursoRepository
    {
        void Add(Recurso recurso);
        Recurso? GetById(int id);
        List<Recurso> GetAll();
        void Update(Recurso recurso);
        void Delete(int id);

        void AddLeitura(Leitura leitura);

        List<Leitura> GetLeiturasComAlerta();
        List<Recurso> GetTopConsumidores(int quantidade);
    }
}