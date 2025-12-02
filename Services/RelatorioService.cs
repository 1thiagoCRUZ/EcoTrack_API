using System.Text;
using EcoTrack.Repositories;

namespace EcoTrack.Services
{
    public class RelatorioService
    {
        private readonly IRecursoRepository _repository;

        public RelatorioService(IRecursoRepository repository)
        {
            _repository = repository;
        }

        public byte[] GerarRelatorioFinanceiro()
        {
            var leituras = _repository.GetLeiturasComAlerta();

            var builder = new StringBuilder();

            builder.AppendLine("ID Leitura;Equipamento;Local;Consumo;Unidade;Preço Unit.;Custo Total (R$);Data;Status");

            foreach (var item in leituras)
            {
                double tarifa = 0;
                string unidade = item.Recurso?.UnidadeMedida ?? "-";

                if (unidade == "kWh") tarifa = 0.95;
                else if (unidade == "m3") tarifa = 5.50;
                else if (unidade == "kg") tarifa = 0.50;

                double custoEstimado = item.Valor * tarifa;
                string status = item.AlertaGerado ? "CRITICO" : "Normal";

                string linha = $"{item.Id};" +
                               $"{item.Recurso?.Nome};" +
                               $"{item.Recurso?.Localizacao};" +
                               $"{item.Valor};" +
                               $"{unidade};" +
                               $"R$ {tarifa:F2};" +
                               $"R$ {custoEstimado:F2};" +
                               $"{item.DataLeitura};" +
                               $"{status}";

                builder.AppendLine(linha);
            }
            return Encoding.UTF8.GetPreamble()
                .Concat(Encoding.UTF8.GetBytes(builder.ToString()))
                .ToArray();
        }
    }
}