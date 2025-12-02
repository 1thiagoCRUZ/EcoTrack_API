using EcoTrack.DTOs;
using EcoTrack.Models;
using EcoTrack.Repositories;

namespace EcoTrack.Services
{
    public class RecursoService
    {
        private readonly IRecursoRepository _repository;

        public RecursoService(IRecursoRepository repository)
        {
            _repository = repository;
        }
        public ResponseEnergiaDto CadastrarEnergia(CreateEnergiaDto dto)
        {
            double emissaoReal = dto.Fonte == TipoFonteEnergia.Solar ? 0 : dto.FatorEmissaoCO2;

            var energia = new Energia
            {
                Nome = dto.Nome,
                Localizacao = dto.Localizacao,
                MetaConsumoMensal = dto.MetaConsumoMensal,
                UnidadeMedida = dto.UnidadeMedida,
                Status = StatusOperacional.Ativo,

                Voltagem = dto.Voltagem,
                Fonte = dto.Fonte,
                FatorEmissaoCO2 = emissaoReal
            };

            _repository.Add(energia);

            return new ResponseEnergiaDto
            {
                Id = energia.Id,
                Nome = energia.Nome,
                Localizacao = energia.Localizacao,
                MetaConsumoMensal = energia.MetaConsumoMensal,
                UnidadeMedida = energia.UnidadeMedida,
                Voltagem = energia.Voltagem,
                FonteDescricao = energia.Fonte.ToString(),
                PegadaCarbono = energia.FatorEmissaoCO2,
                Status = energia.Status.ToString()
            };
        }

        public ResponseAguaDto CadastrarAgua(CreateAguaDto dto)
        {
            var agua = new Agua
            {
                Nome = dto.Nome,
                Localizacao = dto.Localizacao,
                MetaConsumoMensal = dto.MetaConsumoMensal,
                UnidadeMedida = "m3",
                Status = StatusOperacional.Ativo,

                Pressao = dto.Pressao,
                TipoUso = dto.TipoUso
            };

            _repository.Add(agua);

            return new ResponseAguaDto
            {
                Id = agua.Id,
                Nome = agua.Nome,
                Localizacao = agua.Localizacao,
                Meta = agua.MetaConsumoMensal,
                Pressao = agua.Pressao,
                TipoUsoDescricao = agua.TipoUso.ToString(),
                Status = agua.Status.ToString()
            };
        }
        public ResponseResiduoDto CadastrarResiduo(CreateResiduoDto dto)
        {
            var residuo = new Residuo
            {
                Nome = dto.Nome,
                Localizacao = dto.Localizacao,
                MetaConsumoMensal = dto.MetaConsumoMensal,
                UnidadeMedida = "kg",
                Status = StatusOperacional.Ativo,

                TipoMaterial = dto.TipoMaterial,
                Reciclavel = dto.Reciclavel
            };

            _repository.Add(residuo);

            return new ResponseResiduoDto
            {
                Id = residuo.Id,
                Nome = residuo.Nome,
                TipoMaterial = residuo.TipoMaterial,
                IsReciclavel = residuo.Reciclavel,
                MetaGeracao = residuo.MetaConsumoMensal
            };
        }

        public ResponseLeituraDto ProcessarLeitura(CreateLeituraDto dto)
        {
            var recurso = _repository.GetById(dto.RecursoId);
            if (recurso == null) throw new Exception("Recurso não encontrado");

            bool alerta = dto.Valor > (recurso.MetaConsumoMensal * 0.2);

            var leitura = new Leitura
            {
                RecursoId = dto.RecursoId,
                Valor = dto.Valor,
                SensorId = dto.SensorId,
                DataLeitura = DateTime.Now,
                AlertaGerado = alerta
            };

            _repository.AddLeitura(leitura);

            return new ResponseLeituraDto
            {
                Id = leitura.Id,
                RecursoId = leitura.RecursoId,
                Valor = leitura.Valor,
                DataLeitura = leitura.DataLeitura,
                SensorId = leitura.SensorId,
                HouveAlerta = leitura.AlertaGerado,
                MensagemAlerta = alerta ? "ALERTA: Consumo anormal detectado!" : "Operação normal"
            };
        }

        public object GerarDashboard()
        {
            var alertas = _repository.GetLeiturasComAlerta();
            var topConsumidores = _repository.GetTopConsumidores(3);

            return new
            {
                TotalAlertas = alertas.Count,
                UltimosIncidentes = alertas.Select(a => new {
                    Data = a.DataLeitura,
                    Equipamento = a.Recurso?.Nome,
                    Valor = a.Valor
                }),
                MaioresGastadores = topConsumidores.Select(c => new {
                    c.Nome,
                    c.Localizacao,
                    TotalGasto = c.Leituras.Sum(l => l.Valor)
                })
            };
        }
        public List<Recurso> ObterTodos()
        {
            return _repository.GetAll();
        }

        public Recurso? ObterPorId(int id)
        {
            return _repository.GetById(id);
        }

        public void AtualizarMeta(UpdateMetaDto dto)
        {
            var recurso = _repository.GetById(dto.RecursoId);
            if (recurso == null) throw new Exception("Recurso não encontrado");

            recurso.MetaConsumoMensal = dto.NovaMeta;
            _repository.Update(recurso);
        }

        public void RemoverRecurso(int id)
        {
            var recurso = _repository.GetById(id);
            if (recurso == null) throw new Exception("Recurso não encontrado");

            _repository.Delete(id);
        }
    }
}
