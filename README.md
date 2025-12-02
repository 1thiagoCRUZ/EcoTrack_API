# 🌱 EcoTrack API - Monitoramento Sustentável IoT

> Backend inteligente para gestão de recursos (Energia, Água e Resíduos) com simulação de sensores IoT e alertas automáticos.

O **EcoTrack** substitui o monitoramento manual de recursos por um sistema automatizado. A API recebe dados de sensores em tempo real, processa regras de negócio (como estouro de meta de consumo) e calcula métricas de sustentabilidade (Pegada de Carbono).

---

## 🚀 Funcionalidades Principais

* **Cadastro Multi-Recurso:** Gerenciamento de Energia, Água e Resíduos usando **Herança** e Polimorfismo.
* **Simulação IoT:** Endpoint dedicado para receber leituras de sensores fictícios.
* **Inteligência de Alertas:** O sistema verifica automaticamente se o consumo atual ultrapassou a meta definida (Regra: > 20% da meta) e gera um flag de alerta.
* **Dashboard em Tempo Real:** Relatórios gerados via **LINQ** mostrando incidentes críticos e maiores consumidores.
* **Cálculo de CO2:** Estimativa automática de impacto ambiental baseada na fonte de energia.

---

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C# (.NET 9.0)
* **Framework:** ASP.NET Core Web API
* **Banco de Dados:** SQL Server (LocalDB)
* **ORM:** Entity Framework Core (Estratégia TPT - Table Per Type)
* **Documentação:** Swagger (OpenAPI)

---

## 📦 Como Rodar o Projeto

### Pré-requisitos
* [.NET SDK 9.0](https://dotnet.microsoft.com/download) instalado.
* **SQL Server** (Pode ser o LocalDB que vem com o Visual Studio ou SQL Express).
* Git.

### 1. Clonar o Repositório
Abra o terminal e rode:
```bash
git clone [https://github.com/1thiagoCRUZ/EcoTrack_API.git](https://github.com/1thiagoCRUZ/EcoTrack_API.git)
cd EcoTrack_API
```


### 2. Restaurar Dependências
Para baixar os pacotes do NuGet necessários:
```bash
dotnet restore
```

### 3. Configurar o Banco de Dados 
O projeto usa Entity Framework. Você precisa criar o banco localmente usando as Migrations já configuradas.

No terminal, execute os dois comandos abaixo:
```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

### 4. Rodar a API
```bash
dotnet run
```

O terminal mostrará a porta onde o servidor está rodando (ex: http://localhost:5152).

### 5. Acessar a Documentação
Abra seu navegador e acesse o link mostrado no terminal adicionando /swagger no final. Exemplo:
```bash
http://localhost:5152/swagger
```

## 🧪 Como Testar?

Para validar a lógica de **IoT, Alertas Automáticos e Polimorfismo**, siga este roteiro no Swagger após rodar o projeto.

### 1. Cadastrar Equipamento (Energia)
Primeiro, vamos cadastrar um ar-condicionado com uma meta de consumo baixa para facilitar o teste de alerta.

* **Endpoint:** `POST /api/Energia`
* **Ação:** Clique em *Try it out* e cole o JSON abaixo.

```json
{
  "nome": "Ar Condicionado - Servidor",
  "localizacao": "Sala de TI",
  "metaConsumoMensal": 100,
  "unidadeMedida": "kWh",
  "voltagem": 220,
  "fonte": 1,
  "fatorEmissaoCO2": 0.5
}
```

### 2. Simular Leitura Normal
Vamos simular o sensor enviando um dado dentro do padrão esperado.

* **Endpoint:** `POST /api/Monitoramento/leitura`
* **Ação:** Clique em *Try it out* e cole o JSON abaixo.
```json
{
  "recursoId": 1,
  "valor": 50,
  "sensorId": "SENSOR-AC-01"
}
```
* **Resultado Esperado:** O sistema deve retornar status OK e mensagem de "Operação normal".

### 3. Simular Alerta Crítico (A Lógica de Negócio) 🚨
Agora, vamos simular um pico de energia. Enviaremos um valor de 500, que é 5x maior que a meta de 100 definida anteriormente.

* **Endpoint:** `POST /api/Monitoramento/leitura`
* **Ação:** Clique em *Try it out* e cole o JSON abaixo.
```json
{
  "recursoId": 1,
  "valor": 500,
  "sensorId": "SENSOR-AC-01"
}
```

* **Resultado Esperado:**
1. O Backend intercepta o valor alto.
2. O JSON de resposta muda para `"status": "ALERTA"`.
3. A flag `houveAlerta` retorna `true`.

### 4. Verificar Relatório no Dashboard (LINQ) 📊
Por fim, verificamos se o incidente foi registrado e processado pelas queries LINQ.

* **Endpoint:** `GET /api/Monitoramento/dashboard`
* **Ação:** Clique em *Try it out* e execute.

* **Resultado Esperado:**
1. `totalAlertas`: Deve ser maior que 0.
2. `ultimosIncidentes`: Deve listar a leitura de 500 que acabamos de fazer.
3. `maioresGastadores`: O "Ar Condicionado - Servidor" deve aparecer no topo do ranking.
