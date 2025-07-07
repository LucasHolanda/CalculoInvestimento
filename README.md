# 📊 Calculadora de Investimento

Sistema completo para cálculo de investimentos em CDB (Certificado de Depósito Bancário) com interface web moderna e API REST robusta.

## 🏗️ Arquitetura do Projeto

O projeto segue uma arquitetura em camadas com separação clara de responsabilidades:

```
CalculoInvestimento/
├── CalculoInvestimento.Domain/          # Camada de domínio (entidades e regras de negócio)
├── CalculoInvestimento.WebApi/          # API REST (.NET 8)
├── CalculoInvestimento.Tests.Unit/      # Testes unitários
└── CalculoInvestimentoFrontEnd/         # Frontend Angular 19
```

### 📋 Estrutura Detalhada

#### Backend (.NET 8)
- **Domain Layer**: Entidades, interfaces e estratégias de cálculo
- **WebApi Layer**: Controllers, DTOs, validação e configuração
- **Patterns**: CQRS com MediatR, Strategy Pattern, Factory Pattern, Decorator Pattern (Cache)

#### Frontend (Angular 19)
- **Componente Principal**: Calculadora de investimento
- **Serviços**: Comunicação com API REST
- **Interface**: Design responsivo e moderno

## 🚀 Tecnologias Utilizadas

### Backend
- **.NET 8** - Framework principal
- **ASP.NET Core** - Web API
- **MediatR** - Implementação do padrão CQRS
- **AutoMapper** - Mapeamento de objetos
- **FluentValidation** - Validação de dados
- **Swagger** - Documentação da API
- **Docker** - Containerização

### Frontend
- **Angular 19** - Framework frontend
- **TypeScript** - Linguagem de programação
- **CSS3** - Estilização moderna
- **RxJS** - Programação reativa

### Testes
- **xUnit** - Framework de testes
- **NSubstitute** - Mocking
- **FluentAssertions** - Assertions expressivas
- **Coverlet** - Cobertura de código

## 📦 Pré-requisitos

- **.NET 8 SDK**
- **Node.js 18+** e **npm**
- **Docker** (opcional, para execução em container)

## 🛠️ Como Executar

### 1. Backend (API)

```bash
# Navegar para o diretório da API
cd CalculoInvestimento.WebApi

# Restaurar dependências
dotnet restore

# Executar a aplicação
dotnet run
```

A API estará disponível em:
- **URL**: https://localhost:7001 ou http://localhost:5000
- **Swagger**: https://localhost:7001/swagger

### 2. Frontend (Angular)

```bash
# Navegar para o diretório do frontend
cd CalculoInvestimentoFrontEnd

# Instalar dependências
npm install

# Executar a aplicação
npm start
```

O frontend estará disponível em:
- **URL**: http://localhost:4200

### 3. Execução com Docker

```bash
# Executar apenas a API
cd CalculoInvestimento.WebApi
docker-compose up

# Ou executar toda a solution
docker-compose up --build
```

## 🧪 Executando Testes

```bash
# Executar todos os testes
dotnet test

# Executar testes com cobertura
dotnet test --collect:"XPlat Code Coverage"

# Executar testes do frontend
cd CalculoInvestimentoFrontEnd
npm test
```

## 📡 API Endpoints

### POST /api/cdb/calcular

Calcula o retorno de um investimento em CDB.

**Request Body:**
```json
{
  "valor": 1000.00,
  "prazoMeses": 12
}
```

**Response:**
```json
{
  "valorInicial": 1000.00,
  "prazoMeses": 12,
  "imposto": 0.15,
  "valorImposto": 15.50,
  "valorBruto": 1103.33,
  "valorLiquido": 1087.83,
  "valorRendimentoBruto": 103.33,
  "valorRendimentoLiquido": 87.83,
  "dataCalculo": "2024-01-15T10:30:00Z",
  "tb": 1.08,
  "cdi": 0.90
}
```

## 🏛️ Padrões de Projeto Utilizados

### 1. **CQRS (Command Query Responsibility Segregation)**
- `CalcularCdbCommand` - Comando para cálculo
- `CalcularCdbHandler` - Handler que processa o comando
- `CalcularCdbValidator` - Validação do comando

### 2. **Strategy Pattern**
- `ICalcularCdbStrategy` - Interface da estratégia
- `CalcularCdbStrategy` - Implementação do cálculo de CDB

### 3. **Factory Pattern**
- `IInvestimentoFactory` - Interface da factory
- `InvestimentoFactory` - Criação de investimentos

### 4. **Decorator Pattern**
- `CalcularCdbCacheDecorator` - Cache decorator para otimização

### 5. **Dependency Injection**
- Configuração de serviços no `Program.cs`
- Injeção de dependências em todos os componentes

## 📊 Funcionalidades

### Cálculo de CDB
- **Valor Bruto**: Cálculo do montante antes dos impostos
- **Valor Líquido**: Cálculo do montante após impostos
- **Imposto de Renda**: Aplicação da tabela regressiva
- **Rendimentos**: Cálculo de rendimentos brutos e líquidos

### Interface Web
- **Formulário Intuitivo**: Entrada de valor e prazo
- **Resultados Detalhados**: Exibição completa dos cálculos
- **Formatação**: Valores em moeda brasileira
- **Responsivo**: Interface adaptável a diferentes dispositivos

### Cache
- **Memória**: Cache em memória para otimização
- **Performance**: Redução de cálculos repetitivos

## 🔧 Configuração

### Taxas de CDB
As taxas são configuradas através do `appsettings.json`:

```json
{
  "BancoTaxaCdbOptions": {
    "TB": 1.08,
    "CDI": 0.90
  }
}
```

### CORS
Configurado para permitir requisições do frontend Angular:
- **Origem**: http://localhost:4200
- **Métodos**: Todos os métodos HTTP
- **Headers**: Todos os headers

## 🚀 Deploy

### Docker
```bash
# Build da imagem
docker build -t calculo-investimento-api .

# Executar container
docker run -p 5000:8080 calculo-investimento-api
```

### Produção
1. Build do frontend: `npm run build`
2. Build da API: `dotnet publish -c Release`
3. Configurar variáveis de ambiente
4. Deploy em servidor web

## 📝 Contribuição

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

## 👥 Autores

- Desenvolvido com Clean Architecture
- Padrões de projeto modernos
- Testes unitários abrangentes
- Interface de usuário intuitiva

---

**🎯 Objetivo**: Fornecer uma ferramenta completa e confiável para cálculo de investimentos em CDB, com interface moderna e API robusta. 