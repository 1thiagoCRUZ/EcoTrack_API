using EcoTrack.Data;
using EcoTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Repositories
{
    public class RecursoRepository : IRecursoRepository
    {
        private readonly DataContext _context;
        public RecursoRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Recurso recurso)
        {
            _context.Recursos.Add(recurso);
            _context.SaveChanges();
        }
        public Recurso? GetById(int id)
        {
            return _context.Recursos
                .Include(r => r.Leituras)
                .FirstOrDefault(r => r.Id == id);
        }
        public List<Recurso> GetAll()
        {
            return _context.Recursos
                .Include(r => r.Leituras)
                .ToList();
        }
        public void Update(Recurso recurso)
        {
            _context.Recursos.Update(recurso);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var recurso = GetById(id);
            if (recurso != null)
            {
                _context.Recursos.Remove(recurso);
                _context.SaveChanges();
            }
        }
        public void AddLeitura(Leitura leitura)
        {
            _context.Leituras.Add(leitura);
            _context.SaveChanges();
        }

        public List<Leitura> GetLeiturasComAlerta()
        {
            return _context.Leituras
                .Include(l => l.Recurso)
                .Where(l => l.AlertaGerado == true)
                .OrderByDescending(l => l.DataLeitura)
                .ToList();
        }
        public List<Recurso> GetTopConsumidores(int quantidade)
        {
            return _context.Recursos
                           .Include(r => r.Leituras)
                           .OrderByDescending(r => r.Leituras.Sum(l => l.Valor)) 
                           .Take(quantidade) 
                           .ToList();
        }
    }
}