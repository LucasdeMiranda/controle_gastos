# Controle de Gastos 

Sistema desenvolvido para controle de gastos residenciais, permitindo o cadastro de pessoas, cadastro de transações financeiras e consulta de totais.

---

# Tecnologias utilizadas

## Backend

- C#
- .NET Web API
- Entity Framework Core
- SQLite
- REST API

## Frontend

- React
- TypeScript
- Vite
- Axios
- React Router
- React Icons
- CSS

---

# Estrutura do projeto

O projeto foi dividido em duas aplicações independentes:


ControleGastos/

├── backend/
│
│ ├── Controllers/
│ │ ├── PessoasController.cs
│ │ ├── TransacaoController.cs
│ │ └── TotaisController.cs
│ │
│ ├── Models/
│ │ ├── Pessoa.cs
│ │ └── Transacao.cs
│ │
│ ├── DTOs/
│ │ └── TotalporPessoa.cs
│ │
│ ├── Data/
│ │ └── AppDbContext.cs
│ │
│ └── Program.cs
│
└── frontend/

├── src/
│
├── pages/
│   ├── Pessoa.tsx
│   ├── Transacao.tsx
│   └── Totais.tsx
│
├── services/
│   ├── pessoaService.ts
│   ├── transacaoService.ts
│   └── totalService.ts
│
├── types/
│   ├── Pessoa.ts
│   ├── Transacao.ts
│   └── Totais.ts
│
└── styles/

---

# Funcionalidades implementadas

## Cadastro de pessoas

O sistema permite:

- Criar pessoas;
- Listar pessoas cadastradas;
- Excluir pessoas.

Ao excluir uma pessoa, todas as transações associadas a ela também são removidas.

---

## Cadastro de transações

O sistema permite:

- Criar transações;
- Listar transações.

Cada transação possui:

- Identificador;
- Descrição;
- Valor;
- Tipo (Despesa ou Receita);
- Pessoa relacionada.

---

## Consulta de totais

O sistema apresenta:

### Por pessoa:

- Total de receitas;
- Total de despesas;
- Saldo individual.

### Geral:

- Total de receitas;
- Total de despesas;
- Saldo líquido.

---

# Regras de negócio

As regras foram implementadas no backend para garantir segurança e consistência dos dados.

Foram implementadas as seguintes validações:

- Não permite cadastrar pessoas com idade negativa;
- Não permite cadastrar transações para pessoas inexistentes;
- Não permite valores menores ou iguais a zero;
- Pessoas menores de 18 anos não podem cadastrar receitas;
- Ao excluir uma pessoa, todas as suas transações são removidas.

---

# Arquitetura

O projeto utiliza uma arquitetura separada entre frontend e backend.

## Backend

Responsável por:

- Regras de negócio;
- Validação dos dados;
- Comunicação com o banco;
- Exposição dos endpoints REST.

Foi utilizado Entity Framework Core para realizar o mapeamento entre as classes C# e o banco SQLite.

---

## Frontend

Responsável por:

- Interface do usuário;
- Formulários;
- Exibição dos dados;
- Comunicação com a API.

A comunicação com o backend foi organizada através de services utilizando Axios.

---

# Banco de dados

Foi utilizado SQLite como banco de dados.

O acesso aos dados é realizado através do Entity Framework Core.

As entidades principais são:

## Pessoa

- Id
- Nome
- Idade

## Transação

- Id
- Descrição
- Valor
- Tipo
- PessoaId

---

# Como executar o projeto

## Backend

Entre na pasta do backend:

```bash
cd backend

Restaure as dependências:

dotnet restore

Execute a aplicação:

dotnet run

A API ficará disponível no endereço informado pelo .NET.

Frontend

Entre na pasta do frontend:

cd frontend

Instale as dependências:

npm install

Execute o projeto:

npm run dev

A aplicação ficará disponível no endereço informado pelo Vite.

Endpoints principais
Pessoas

Criar pessoa

POST /api/Pessoas

Listar pessoas

GET /api/Pessoas

Excluir pessoa

DELETE /api/Pessoas/{id}
Transações

Criar transação

POST /api/Transacao

Listar transações

GET /api/Transacao
Totais

Consultar totais

GET /api/Totais
Decisões técnicas

Foi utilizado DTO para retornar os totais calculados, pois essas informações não precisam ser armazenadas no banco de dados.

As regras de negócio foram mantidas no backend para evitar manipulação pelo frontend.

O frontend foi dividido em páginas independentes utilizando React Router.

Os serviços de comunicação com a API foram separados para melhorar organização e manutenção do código.

Controle de versão

O projeto utiliza Git para versionamento do código.

Arquivos temporários, dependências e bancos locais são ignorados através do .gitignore.


Esse arquivo já está no formato esperado para um repositório GitHub de desafio técnico.

