# Calculadora de Investimento - Frontend

Uma aplicação Angular moderna e responsiva para cálculo de investimentos com interface intuitiva e design elegante.

## 🚀 Funcionalidades

- **Cálculo de Investimento**: Interface simples para inserir valor inicial e prazo
- **Resultados Detalhados**: Exibição completa dos valores brutos, líquidos e impostos
- **Design Responsivo**: Funciona perfeitamente em desktop, tablet e mobile
- **Formatação Brasileira**: Valores em Real (R$) e datas no formato brasileiro
- **Feedback Visual**: Estados de loading, erro e sucesso bem definidos
- **Configuração por Ambiente**: URLs da API configuráveis por environment
- **Componente Standalone**: Arquitetura moderna do Angular 19

## 📋 Pré-requisitos

- Node.js (versão 16 ou superior)
- Angular CLI (versão 19 ou superior)

## 🛠️ Instalação

1. Clone o repositório:
```bash
git clone <url-do-repositorio>
cd CalculoInvestimentoFrontEnd
```

2. Instale as dependências:
```bash
npm install
```

3. Execute a aplicação:
```bash
npm start
```

4. Acesse a aplicação em: `http://127.0.0.1:4200`

## 📊 Como Usar

1. **Insira o Valor Inicial**: Digite o valor que deseja investir em Reais
2. **Defina o Prazo**: Especifique o número de meses para o investimento
3. **Clique em Calcular**: A aplicação processará os dados e exibirá os resultados
4. **Analise os Resultados**: Visualize valores brutos, líquidos, impostos e rendimentos

## 🔧 Configuração da API

A aplicação está configurada para usar sua API real na URL `http://localhost:5198`.

### Configuração por Ambiente

#### Desenvolvimento
Edite o arquivo `src/environments/environment.ts`:
```typescript
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5198'
};
```

#### Produção
Edite o arquivo `src/environments/environment.prod.ts`:
```typescript
export const environment = {
  production: true,
  apiUrl: 'https://sua-api-producao.com' // Altere para a URL de produção
};
```

### Endpoint da API
- **URL**: `${apiUrl}/calcular-cdb`
- **Método**: POST
- **Content-Type**: application/json

### Estrutura da Request:
```json
{
  "valor": 1000,
  "prazoMeses": 100
}
```

### Estrutura da Response:
```json
{
  "prazoMeses": 100,
  "valorInicial": 1000,
  "valorBruto": 2630.85,
  "valorLiquido": 2386.22,
  "imposto": 0.15,
  "valorImposto": 244.63,
  "valorRendimentoLiquido": 1386.22,
  "valorRendimentoBruto": 1630.85,
  "dataCalculo": "2025-07-07T23:02:50.5566923Z"
}
```

## 🎨 Características do Design

- **Gradientes Modernos**: Cores atrativas e profissionais
- **Cards Responsivos**: Layout em grid que se adapta a diferentes telas
- **Animações Suaves**: Transições e efeitos visuais elegantes
- **Tipografia Clara**: Hierarquia visual bem definida
- **Cores Semânticas**: Verde para valores positivos, vermelho para negativos

## 📱 Responsividade

A aplicação é totalmente responsiva e funciona em:
- **Desktop**: Layout em duas colunas
- **Tablet**: Layout adaptativo
- **Mobile**: Layout em coluna única otimizado para toque

## 🛠️ Tecnologias Utilizadas

- **Angular 19**: Framework principal com componentes standalone
- **TypeScript**: Linguagem de programação com strict mode
- **CSS Grid & Flexbox**: Layout responsivo
- **HTTP Client**: Comunicação com API usando provideHttpClient()
- **Forms Module**: Gerenciamento de formulários
- **Environment Configuration**: Configuração por ambiente

## 📁 Estrutura do Projeto

```
src/
├── app/
│   ├── investment-calculator/
│   │   ├── investment-calculator.component.ts    # Componente standalone
│   │   ├── investment-calculator.component.html  # Template
│   │   ├── investment-calculator.component.css   # Estilos
│   │   └── investment-calculator.service.ts      # Serviço da API
│   ├── app.component.ts
│   ├── app.component.html
│   └── app.module.ts
├── environments/
│   ├── environment.ts                           # Configuração desenvolvimento
│   └── environment.prod.ts                      # Configuração produção
├── styles.css
└── main.ts
```

## 🚀 Build para Produção

Para gerar uma versão otimizada para produção:

```bash
npm run build
```

Ou especificamente para produção:
```bash
ng build --configuration=production
```

Os arquivos serão gerados na pasta `dist/` e automaticamente usará o `environment.prod.ts`.

## 🔍 Características Técnicas

### Componente Standalone
- Arquitetura moderna do Angular 19
- Imports automáticos de dependências
- Melhor tree-shaking e performance

### Null Safety
- Operador de navegação segura (`?.`) em todas as propriedades
- Validação explícita de formulários
- Tratamento robusto de erros

### HTTP Client Moderno
- Uso de `provideHttpClient()` ao invés do deprecated `HttpClientModule`
- Configuração centralizada no módulo principal

### Environment Configuration
- Troca automática de environments em build de produção
- Configuração centralizada de URLs da API
- Fácil manutenção para diferentes ambientes

## 🐛 Solução de Problemas

### Erro de Parser
Se encontrar erros de parser relacionados a propriedades opcionais, verifique:
- Uso correto do operador `?.` em templates
- Validação explícita em condições de botões

### Erro de HTTP Client
Se houver problemas com requisições HTTP:
- Verifique se `provideHttpClient()` está no array de providers
- Confirme se a URL da API está correta no environment

### Erro de Forms
Se houver problemas com formulários:
- Verifique se `FormsModule` está importado no componente standalone
- Confirme se o componente está configurado como standalone

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

## 📞 Suporte

Para dúvidas ou suporte, entre em contato através dos issues do repositório.
